using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace HashMap 
{
    class Hash<TKey, TVal> : IDictionary<TKey, TVal>
    {
        LinkedList<KeyValuePair<TKey, TVal>>[] array;
        int valCount;
        public Hash()
        {
            array = new LinkedList<KeyValuePair<TKey, TVal>>[1];
            valCount = 0;
        }

        public TVal this[TKey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<TKey> Keys => throw new NotImplementedException();

        public ICollection<TVal> Values => throw new NotImplementedException();

        public ICollection<TVal> Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        int ICollection<KeyValuePair<TKey, TVal>>.Count => throw new NotImplementedException();

        public void Add(KeyValuePair<TKey, TVal> item)
        {
            valCount++;
            if(valCount == array.Length)
            {
                Resize();
            }
            int value = item.Key.GetHashCode();
            int moddedVal = Math.Abs(value % array.Length);
            string toReturn = item.Key.ToString();
            toReturn += value;
            Console.WriteLine(toReturn);
            if (array[moddedVal] == default)
            {
                LinkedList<KeyValuePair<TKey, TVal>> list = new LinkedList<KeyValuePair<TKey, TVal>>();
                list.AddFirst(item);
                array[moddedVal] = list;
            }
            else
            {
                if(array[moddedVal].Contains(item))
                {
                    return;
                }
                else
                {
                    array[moddedVal].AddLast(item);
                }
            }
            
        }

        public void Clear()
        {
            array = null;
        }

        public void Resize()
        {
            LinkedList<KeyValuePair<TKey, TVal>>[] newArray = new LinkedList<KeyValuePair<TKey, TVal>>[array.Length*2];
            for(int i = 0; i<array.Length; i++)
            {
                LinkedList<KeyValuePair<TKey, TVal >> list = array[i];
                if (array[i] != default)
                {
                    int listCount = list.Count;
                    for (int a = 0; a < listCount; a++)
                    {
                        KeyValuePair<TKey, TVal> pair = list.First.Value;
                        int result = pair.Key.GetHashCode();
                        int moddedVal = Math.Abs(result % newArray.Length);
                        if (newArray[moddedVal] == default)
                        {
                            LinkedList<KeyValuePair<TKey, TVal>> newList = new LinkedList<KeyValuePair<TKey, TVal>>();
                            newList.AddFirst(pair);
                            newArray[moddedVal] = newList;
                        }
                        else
                        {
                            newArray[moddedVal].AddLast(pair);
                        }
                        list.RemoveFirst();
                    }
                }
            }
            array = newArray;

        }

        public bool Contains(KeyValuePair<TKey, TVal> item)
        {
            int toReturn = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != default)
                {
                    if (array[i].Contains(item))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ContainsKey(TKey key)
        {
            int hash = key.GetHashCode();
            int modded = Math.Abs(hash % array.Length);
            if (array[modded] != default)
            {
                LinkedList<KeyValuePair<TKey, TVal>> possibleList = array[modded];
                for (int i = 0; i < possibleList.Count; i++)
                {
                    KeyValuePair<TKey, TVal> pair = possibleList.First.Value;
                    if (pair.Key.Equals(key))
                    {
                        return true;
                    }
                    else
                    {
                        possibleList.RemoveFirst();
                    }
                }
                return false;
            }
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TVal>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TVal>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            int hash = key.GetHashCode();
            int modded = Math.Abs(hash % array.Length);
            LinkedList<KeyValuePair<TKey, TVal>> possibleList = array[modded];
            for(int i = 0; i<possibleList.Count; i++)
            {
                KeyValuePair<TKey, TVal> pair = possibleList.First.Value;
                if(pair.Key.Equals(key))
                {
                    if (array.Length == 1)
                    {
                        array[modded] = default;
                    }
                    else
                    {
                        array[modded].RemoveFirst();
                    }
                    return true;
                }
                possibleList.RemoveFirst();
            }
            return false;
        }

        public bool Remove(KeyValuePair<TKey, TVal> item)
        {
            return Remove(item.Key); 
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TVal value)
        {
            throw new NotImplementedException();
        }

        void IDictionary<TKey, TVal>.Add(TKey key, TVal value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
