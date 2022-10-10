#nullable disable

namespace BasicInformation.Application.Responses.Base
{
    public class BaseLocationResponse : BaseResponse<long>
    { 
        public string Title { get; set; }
    }
}
