﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cache
{
    public interface ICache<TKey, TValue>
    {
        bool TryGetValue(TKey key, out TValue value);
        void Put(TKey key, TValue value);
    }
}
