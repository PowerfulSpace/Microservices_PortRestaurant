using static PS.PortRestaurant.Web.SD;

namespace PS.PortRestaurant.Web.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
