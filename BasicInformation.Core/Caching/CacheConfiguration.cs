
namespace BasicInformation.Core.Caching
{
    public class CacheConfiguration
    {
        public int AbsoluteExpirationInHours { get; set; }
        public int SlidingExpirationInMinutes { get; set; }
    }
}
