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
    }
}