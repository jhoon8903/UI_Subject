using System;
using System.Collections.Generic;
using System.Linq;
using _01.Scripts.Data;
using _01.Scripts.Interfaces;

namespace _01.Scripts.Loader
{
    [Serializable]
    public class CharacterDataLoader : ILoader<int, CharacterData>
    {
        public List<CharacterData> character = new();

        public Dictionary<int, CharacterData> CreateData()
        {
            return character.ToDictionary(player => player.PrimeKey);
        }
    }
}