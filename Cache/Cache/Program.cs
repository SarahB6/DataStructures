using System;

namespace Cache
{
    class Program
    {
        static void Main(string[] args)
        {
            LRUCache<string, int> cache = new LRUCache<string, int>(5);
            cache.Put("a", 1);
            cache.Put("b", 2);
            cache.Put("c", 3);
            cache.TryGetValue("b", out var v);
            cache.Put("d", 4);
            cache.Put("e", 5);
            cache.Put("f", 6);
            cache.TryGetValue("e", out var v2);

        }
    }
}
