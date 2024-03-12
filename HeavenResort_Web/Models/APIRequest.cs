using static HeavenResort_Utility.SD;

namespace HeavenResort_Web.Models
{
    public class APIRequest
    {
        public APIType APIType { get; set; } = APIType.GET;
        public string URL { get; set; }
        public object Data { get; set; }
    }
}
