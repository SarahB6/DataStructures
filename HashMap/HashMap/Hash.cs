using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace HashMap 
{
    public class Hash<TKey, TVal> : IDictionary<TKey, TVal>
    {
        LinkedList<KeyValuePair<TKey, TVal>>[] array;
        int valCount;
        List<TKey> keys;
        List<TVal> vals;
        private bool isRead;

        public Hash()
        {
            array = new LinkedList<KeyValuePair<TKey, TVal>>[1];
            valCount = 0;
            vals = new List<TVal>();
            keys = new List<TKey>();
            isRead = false;
        }
        public Hash(bool readOnly)
        {
            array = new LinkedList<KeyValuePair<TKey, TVal>>[1];
            valCount = 0;
            vals = new List<TVal>();
            keys = new List<TKey>();
            isRead = readOnly;
        }

        public TVal this[TKey key] {
            get => vals[keys.IndexOf(key)];
            set
            {
                TKey thisKey = keys[vals.IndexOf(value)];
                KeyValuePair<TKey, TVal> ogpair = new KeyValuePair<TKey, TVal>(thisKey, value);
                int hash = key.GetHashCode();
                int modded = Math.Abs(hash % array.Length);
                LinkedList<KeyValuePair<TKey, TVal>> possibleList = array[modded];
                bool done = false;
                if (possibleList != default)
                {
                    for(int i = 0; i<possibleList.Count; i++)
                    {
                        KeyValuePair<TKey, TVal> pair = possibleList.First.Value;
                        if (pair.Key.Equals(key))
                        {
                            possibleList.RemoveFirst();
                            possibleList.AddFirst(ogpair);
                            done = true;

                        }
                        else
                        {
                            possibleList.RemoveFirst();
                        }
                    }
                }
                if(done != true)
                {
                    possibleList.AddLast(ogpair);
                }

            }
        }

        public ICollection<TKey> Keys => keys;

        public ICollection<TVal> Values => vals;

        public int Count => valCount;

        public bool IsReadOnly => isRead;

        int ICollection<KeyValuePair<TKey, TVal>>.Count => valCount;

        public void Add(KeyValuePair<TKey, TVal> item)
        {
            if (!isRead && !Contains(item))
            {
                valCount++;
                if (valCount == array.Length)
                {
                    Resize();
                }
                int value = item.Key.GetHashCode();
                int moddedVal = Math.Abs(value % array.Length);
                if (array[moddedVal] == default)
                {
                    LinkedList<KeyValuePair<TKey, TVal>> list = new LinkedList<KeyValuePair<TKey, TVal>>();
                    list.AddFirst(item);
                    array[moddedVal] = list;
                    keys.Add(item.Key);
                    vals.Add(item.Value);
                }
                else
                {
                    if (array[moddedVal].Contains(item))
                    {
                        return;
                    }
                    else
                    {
                        array[moddedVal].AddLast(item);
                        keys.Add(item.Key);
                        vals.Add(item.Value);
                    }
                }
            }
            else if(isRead)
            {
                throw new InvalidOperationException("Is Read Only");
            }
            else
            {
                throw new InvalidOperationException("Already Exists in Hash");
            }
            
        }

        public void Clear()
        {
            if (!isRead)
            {
                LinkedList<KeyValuePair<TKey, TVal>>[] list = new LinkedList<KeyValuePair<TKey, TVal>>[1];
                array = list;
            }
            else
            {
                throw new InvalidOperationException("Is Read Only");
            }
        }

        public void Resize()
        {
            if (!isRead)
            {
                LinkedList<KeyValuePair<TKey, TVal>>[] newArray = new LinkedList<KeyValuePair<TKey, TVal>>[array.Length * 2];
                for (int i = 0; i < array.Length; i++)
                {
                    LinkedList<KeyValuePair<TKey, TVal>> list = array[i];
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
            else
            {
                throw new InvalidOperationException("Is Read Only");
            }

        }

        public bool Contains(KeyValuePair<TKey, TVal> item)
        {
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
           int counter = arrayIndex;
           for(int i = 0; i<this.array.Length; i++)
            {
                if(this.array[i] != default)
                {
                    if (this.array[i].Count != 0)
                    {
                        LinkedList<KeyValuePair<TKey, TVal>> newList = this.array[i];
                        for(int a = 0; a<newList.Count; a++)
                        {
                            KeyValuePair<TKey, TVal> pair = newList.First.Value;
                            array[counter] = pair;
                            counter++;
                            newList.RemoveFirst();
                        }
                        
                        
                    }
                }
            }
        }

        public IEnumerator<KeyValuePair<TKey, TVal>> GetEnumerator()
        {
            for(int i =0; i<array.Length; i++)
            {
                if(array[i] != null)
                {
                    if (array[i].Count != 0)
                    {
                        LinkedList<KeyValuePair<TKey, TVal>> newList = this.array[i];
                        for (int a = 0; a < newList.Count; a++)
                        {
                            KeyValuePair<TKey, TVal> pair = newList.First.Value;
                            yield return newList.First.Value;
                            newList.RemoveFirst();
                        }
                    }
                }
                            
            }
        }

        public bool Remove(TKey key)
        {
            if (!isRead)
            {
                if (keys.Contains(key))
                {
                    int index = keys.IndexOf(key);
                    keys.Remove(key);
                    vals.RemoveAt(index);
                    int hash = key.GetHashCode();
                    int modded = Math.Abs(hash % array.Length);
                    LinkedList<KeyValuePair<TKey, TVal>> possibleList = array[modded];
                    for (int i = 0; i < possibleList.Count; i++)
                    {
                        KeyValuePair<TKey, TVal> pair = possibleList.First.Value;
                        if (pair.Key.Equals(key))
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
                }
                return false;
            }
            else
            {
                throw new InvalidOperationException("Is Read Only");
            }
        }

        public bool Remove(KeyValuePair<TKey, TVal> item)
        {
            return Remove(item.Key); 
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TVal value)
        {
            if(ContainsKey(key))
            {
                for(int i = 0; i<array.Length; i++)
                {
                    if(array[i] != default)
                    {
                        if(array[i].Count != 0)
                        {
                            LinkedList<KeyValuePair<TKey, TVal>> newList = this.array[i];
                            for (int a = 0; a < newList.Count; a++)
                            {
                                KeyValuePair<TKey, TVal> pair = newList.First.Value;
                                if(pair.Key.Equals(key))
                                {
                                    value = pair.Value;
                                    return true;
                                }

                            }
                        }
                    }
                }
            }
            value = default;
            return false;
        }

        void IDictionary<TKey, TVal>.Add(TKey key, TVal value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
