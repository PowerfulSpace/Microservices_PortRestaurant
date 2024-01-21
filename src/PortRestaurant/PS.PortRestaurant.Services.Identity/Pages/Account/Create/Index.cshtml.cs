using Duende.IdentityServer.Events;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS.PortRestaurant.Services.Identity.Models;
using System.Security.Claims;


namespace PortRestaurant.Pages.Create;

[SecurityHeaders]
[AllowAnonymous]
public class Index : PageModel
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IClientStore _clientStore;

    private readonly IIdentityServerInteractionService _interaction;
    private readonly IEventService _events;
    private readonly IAuthenticationSchemeProvider _schemeProvider;
    private readonly IIdentityProviderStore _identityProviderStore;

    [BindProperty]
    public InputModel Input { get; set; }

    public Index(
            IIdentityServerInteractionService interaction,
            IAuthenticationSchemeProvider schemeProvider,
            IIdentityProviderStore identityProviderStore,
            IEventService events,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IClientStore clientStore)
    {
        _interaction = interaction;
        _schemeProvider = schemeProvider;
        _identityProviderStore = identityProviderStore;
        _events = events;
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _clientStore = clientStore;
    }

    public async Task<IActionResult> OnGet(string returnUrl)
    {
        Input = await BuildRegisterViewModelAsync(returnUrl);
        return Page();
    }
        
    public async Task<IActionResult> OnPost()
    {
        ViewData["ReturnUrl"] = Input.ReturnUrl;
        ViewData["Roles"] = await LendRoles();

        var errors = ModelState
        .Where(x => x.Value.Errors.Count > 0)
        .Select(x => new { x.Key, x.Value.Errors })
        .ToArray();

        if (ModelState.IsValid)
        {

            var user = new ApplicationUser
            {
                UserName = Input.Username,
                Email = Input.Email,
                EmailConfirmed = true,
                FirstName = Input.FirstName,
                LastName = Input.LastNAme
            };

            var result = await _userManager.CreateAsync(user, Input.Password);
            if (result.Succeeded)
            {
                if (!_roleManager.RoleExistsAsync(Input.RoleName).GetAwaiter().GetResult())
                {
                    var userRole = new IdentityRole
                    {
                        Name = Input.RoleName,
                        NormalizedName = Input.RoleName,

                    };
                    await _roleManager.CreateAsync(userRole);
                }

                await _userManager.AddToRoleAsync(user, Input.RoleName);
                await _userManager.AddClaimsAsync(user, new Claim[]{
                        new Claim(JwtClaimTypes.Name, Input.Username),
                        new Claim(JwtClaimTypes.Email, Input.Email),
                        new Claim(JwtClaimTypes.FamilyName, Input.FirstName),
                        new Claim(JwtClaimTypes.GivenName, Input.LastNAme),
                        new Claim(JwtClaimTypes.WebSite, "http://"+Input.Username+".com"),
                        new Claim(JwtClaimTypes.Role,"User") });

                var context = await _interaction.GetAuthorizationContextAsync(Input.ReturnUrl);
                var loginresult = await _signInManager.PasswordSignInAsync(Input.Username, Input.Password, false, lockoutOnFailure: true);
                if (loginresult.Succeeded)
                {
                    var checkuser = await _userManager.FindByNameAsync(Input.Username);
                    await _events.RaiseAsync(new UserLoginSuccessEvent(checkuser.UserName, checkuser.Id, checkuser.UserName, clientId: context?.Client.ClientId));

                    if (context != null)
                    {
                        if (context.IsNativeClient())
                        {
                            // The client is native, so this change in how to
                            // return the response is for better UX for the end user.
                            return this.LoadingPage(Input.ReturnUrl);
                        }

                        // we can trust model.ReturnUrl since GetAuthorizationContextAsync returned non-null
                        return Redirect(Input.ReturnUrl);
                    }

                    // request for a local page
                    if (Url.IsLocalUrl(Input.ReturnUrl))
                    {
                        return Redirect(Input.ReturnUrl);
                    }
                    else if (string.IsNullOrEmpty(Input.ReturnUrl))
                    {
                        return Redirect("~/");
                    }
                    else
                    {
                        // user might have clicked on a malicious link - should be logged
                        throw new Exception("invalid return URL");
                    }
                }

            }
        }

        // If we got this far, something failed, redisplay form
        //return View(model);
        return Page();
    }



    private async Task<InputModel> BuildRegisterViewModelAsync(string returnUrl)
    {
        var context = await _interaction.GetAuthorizationContextAsync(returnUrl);

        ViewData["Roles"] = await LendRoles();
        if (context?.IdP != null && await _schemeProvider.GetSchemeAsync(context.IdP) != null)
        {
            var local = context.IdP == Duende.IdentityServer.IdentityServerConstants.LocalIdentityProvider;

            // this is meant to short circuit the UI and only trigger the one external IdP
            var vm = new InputModel
            {
                EnableLocalLogin = local,
                ReturnUrl = returnUrl,
                Username = context?.LoginHint,
            };

            if (!local)
            {
                vm.ExternalProviders = new[] { new ExternalProvider { AuthenticationScheme = context.IdP } };
            }

            return vm;
        }

        var schemes = await _schemeProvider.GetAllSchemesAsync();
        var providers = schemes
        .Where(x => x.DisplayName != null)
            .Select(x => new ExternalProvider
            {
                DisplayName = x.DisplayName ?? x.Name,
                AuthenticationScheme = x.Name
            }).ToList();

        var allowLocal = true;
        if (context?.Client.ClientId != null)
        {
            var client = await _clientStore.FindEnabledClientByIdAsync(context.Client.ClientId);
            if (client != null)
            {
                allowLocal = client.EnableLocalLogin;

                if (client.IdentityProviderRestrictions != null && client.IdentityProviderRestrictions.Any())
                {
                    providers = providers.Where(provider => client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme)).ToList();
                }
            }
        }

        return new InputModel()
        {
            AllowRememberLogin = AccountOptions.AllowRememberLogin,
            EnableLocalLogin = allowLocal && AccountOptions.AllowLocalLogin,
            ReturnUrl = returnUrl,
            Username = context?.LoginHint,
            ExternalProviders = providers.ToArray(),
        };
    }



    private async Task<List<string>> LendRoles()
    {
        List<string> roles = new List<string>
            {
                "Admin",
                "Customer"
            };
        return roles;
    }


}