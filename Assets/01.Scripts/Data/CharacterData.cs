using System;
using System.Collections.Generic;

namespace _01.Scripts.Data
{
    [Serializable]
    public class CharacterData
    {
        #region Property
        public string PrimeKey { get => _primeKey; set => _primeKey = value; }
        public string Name { get => _name; set => _name = value; }
        public JobClass JobClass { get => _jobClass; set => _jobClass = value; }
        public int Level { get => _level; set => _level = value; }
        public int Exp { get => _exp; set => _exp = value; }
        public int Gold { get => _gold; set => _gold = value; }
        public int Damage { get => _damage; set => _damage = value; }
        public int Defense { get => _defense; set => _defense = value; }
        public int CriticalRate { get => _criticalRate; set => _criticalRate = value; }
        public Dictionary<int, Inventory> Inventory { get => _inventory; set => _inventory = value; }
        #endregion

        #region Field
        private string _primeKey;
        private string _name;
        private JobClass _jobClass;
        private int _level;
        private int _exp;
        private int _currentExp;
        private int _gold;
        private int _damage;
        private int _defense;
        private int _criticalRate;
        private Dictionary<int, Inventory> _inventory;
        #endregion
    }
}
