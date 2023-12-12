using System;
using System.Collections.Generic;
using System.Linq;
using _01.Scripts.Data;
using _01.Scripts.Interfaces;

namespace _01.Scripts.Loader
{
    [Serializable]
    public class ItemDataLoader : ILoader<string, ItemData>
    {
        public List<ItemData> items = new();

        public Dictionary<string, ItemData> CreateData()
        {
            return items.ToDictionary(item => item.PrimeKey);
        }
    }
}