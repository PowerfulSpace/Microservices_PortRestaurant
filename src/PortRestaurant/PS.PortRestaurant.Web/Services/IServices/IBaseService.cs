using PS.PortRestaurant.Web.Models;
using PS.PortRestaurant.Web.Models.Dto;

namespace PS.PortRestaurant.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        public ResponseDto ResponseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
