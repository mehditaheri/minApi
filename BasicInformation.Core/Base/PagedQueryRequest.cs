
namespace BasicInformation.Core.Base
{
    /// <summary>
    /// sample is ?page=1&size=10
    /// </summary>
    public class PagedQueryRequest
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
