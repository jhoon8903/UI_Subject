using System;
using UnityEngine;

namespace _01.Scripts.Data
{
    public enum Itemtypes
    {
        Armor,
        Back,
        Cloth,
        FaceHair,
        Hair,
        Helmet,
        Pants,
        Shield,
        Weapons
    }

    public enum EquipPosition
    {
        Back,
        ClothBody,
        BodyArmor,
        Head,
        FaceHair,
        LeftArm,
        LeftShoulder,
        LeftWeapon,
        LeftShield,
        RightArm,
        RightShoulder,
        RightWeapon,
        RightShield,
        LeftPants,
        RightPants 
    }

    [Serializable]
    public class ItemData
    {
        #region Property
        public string PrimeKey { get; set; }
        public Sprite Sprite { get; set; }
        public Itemtypes Type { get; set; }
        public EquipPosition[] EquipPositions { get; set; }
        public int Attribute { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }
        #endregion
    }
}