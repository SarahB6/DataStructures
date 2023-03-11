using System;
using System.Collections.Generic;
using System.Text;

namespace Cache
{
    class LRUCache<TKey, TValue> : ICache<TKey, TValue>
    {
        LinkedList<KeyValuePair<TKey, TValue>> list;
        Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>> Dict;
        int capacity;
        int currentNum;

        public LRUCache(int given)
        {
            list = new LinkedList<KeyValuePair<TKey, TValue>>();
            Dict = new Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>>();
            capacity = given;
            currentNum = 0;
        }
        public void Put(TKey key, TValue value)
        {
            if (!Dict.ContainsKey(key))
            {
                if (currentNum < capacity)
                {

                    currentNum++;
                }
                else
                {
                    getRid();
                }
                KeyValuePair<TKey, TValue> pair = new KeyValuePair<TKey, TValue>(key, value);
                list.AddFirst(pair);
                Dict.Add(key, list.First);
            }
            
        }

        private void getRid()
        {
            TKey val = list.Last.Value.Key;
            list.RemoveLast();
            Dict.Remove(val);

        }
        public bool TryGetValue(TKey key, out TValue value) //reorders list
        {
            if (Dict.TryGetValue(key, out var node))
            {
                list.Remove(node);
                list.AddFirst(node);
                TValue val = node.Value.Value;
                value = val;
                return true;
                
            }
            value = default;
            return false;
        }
    }
}
