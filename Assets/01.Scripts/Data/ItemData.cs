using System;
using UnityEngine;

namespace _01.Scripts.Data
{
    public enum Itemtypes
    {
        Head,
        Body,
        Weapon,
        Shield,
    }

    [Serializable]
    public class ItemData
    {
        #region Property

        public int PrimeKey
        {
            get => _primeKey;
            set => _primeKey = value;
        }

        public Sprite Sprite
        {
            get => _sprite;
            set => _sprite = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public Itemtypes Type
        {
            get => _type;
            set => _type = value;
        }

        public int Attribute
        {
            get => _attribute;
            set => _attribute = value;
        }

        public string Desc
        {
            get => _desc;
            set => _desc = value;
        }

        public int Price
        {
            get => _price;
            set => _price = value;
        }

        #endregion
        private int _primeKey;
        private Sprite _sprite;
        private string _name;
        private Itemtypes _type;
        private int _attribute;
        private string _desc;
        private int _price;
    }
}