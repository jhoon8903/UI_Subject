using System;
using System.Collections.Generic;
using System.Linq;
using _01.Scripts.Data;
using _01.Scripts.Interfaces;

namespace _01.Scripts.Loader
{
    [Serializable]
    public class CharacterDataLoader : ILoader<string, CharacterData>
    {
        public List<CharacterData> character = new();

        public Dictionary<string, CharacterData> CreateData()
        {
            return character.ToDictionary(player => player.PrimeKey);
        }

        void ILoader<string, CharacterData>.MapData(string[] row)
        {
            character.Add(new CharacterData
            {
                PrimeKey = row[0],
                Name = row[1],
                JobClass = (JobClass)Enum.Parse(typeof(JobClass),row[2]),
                Level = int.Parse(row[3]), 
                Damage = int.Parse(row[4]),
                Defense = int.Parse(row[5]), 
                CriticalRate = int.Parse(row[6]), 
                Inventory = null
            });
        }
    }
}