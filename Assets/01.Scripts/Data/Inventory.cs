using System;

namespace _01.Scripts.Data
{
    [Serializable]
    public class Inventory
    {
        private bool _isEquipment;
        private bool _isHad;

        public bool IsEquipment
        {
            get => _isEquipment; 
            set => _isEquipment = value;
        }
        public bool IsHad
        {
            get => _isHad;
            set => _isHad = value;
        }
    }
}