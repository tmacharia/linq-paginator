using Common;
using System;

namespace Caching
{
    public struct CacheItem : IEquatable<CacheItem>
    {
        public CacheItem(string key,object value, int maxSeconds=30)
            : this(key,value,TimeSpan.FromSeconds(maxSeconds))
        {

        }
        public CacheItem(string key, object value, TimeSpan period)
        {
            Index = 0;
            Key = key;
            Type = value.GetType();
            Value = value;
            Timestamp = DateTime.Now;
            Expiry = Timestamp.Add(period);
        }
        public int Index { get; set; }
        public string Key { get; set; }
        public string FullKey
        {
            get
            {
                return $"{Key}{Index}";
            }
        }
        public Type Type { get; set; }
        public object Value { get; set; }
        public DateTime Timestamp { get; set; }
        private DateTime Expiry { get; set; }

        public bool HasExpired => DateTime.Now > Expiry;

        public override bool Equals(object obj)
        {
            return Equals(obj as CacheItem?);
        }

        public override int GetHashCode()
        {
            int hash = 3030;
            hash = (hash * 7) + Index.GetHashCode();
            hash = (hash * 7) + Key.GetHashCode();
            return hash;
        }

        public static bool operator == (CacheItem left, CacheItem right) => left.Equals(right);

        public static bool operator != (CacheItem left, CacheItem right) => !(left == right);

        public bool Equals(CacheItem other)
        {
            return other != null && Index == other.Index && Key == other.Key;
        }
    }
}
