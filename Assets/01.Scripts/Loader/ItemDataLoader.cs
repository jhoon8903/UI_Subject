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

        void ILoader<string, ItemData>.MapData(string[] row)
        {
            var equipPosStrings = row[4].Trim('[', ']').Split('/');
            var equipPosEnums = equipPosStrings.Select(s => (EquipPosition)Enum.Parse(typeof(EquipPosition), s)).ToArray();

            items.Add(new ItemData
            {
                PrimeKey = row[0],
                Type = (Itemtypes)Enum.Parse(typeof(Itemtypes), row[1]),
                Attribute = int.Parse(row[2]),
                Price = int.Parse(row[3]),
                EquipPositions = equipPosEnums
            });
        }
    }
}