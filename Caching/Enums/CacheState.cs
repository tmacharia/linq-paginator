using System.ComponentModel;

namespace Caching.Enums
{
    public enum CacheState
    {
        [Description("Open/Waiting")]
        Open=0,
        [Description("Reading")]
        Reading=1,
        [Description("Cleaning Up")]
        Cleanup=2,
        [Description("Writing")]
        Writing=3
    }
}
