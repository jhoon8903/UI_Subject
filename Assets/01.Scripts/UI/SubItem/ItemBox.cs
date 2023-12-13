using System;
using System.Collections.Generic;
using System.Linq;
using _01.Scripts.Characters;
using _01.Scripts.Data;
using _01.Scripts.Managers;
using _01.Scripts.UI.Base;
using _01.Scripts.UI.PopUp;
using _01.Scripts.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _01.Scripts.UI.SubItem
{
    public class ItemBox : UIPopup
    {
        private MainManager _mainManager;

        public Sprite ItemSprite { get; set; }

        public Sprite EquipmentIcon { get; set; }

        public TextMeshProUGUI ItemDesc { get; set; }

        public ItemData ItemData
        {
            get => _itemData;
            set
            {
                _itemData = value;
                _itemPrimeKey = _itemData.PrimeKey;
                // ItemDesc.text = _itemData.Desc;
            }
        }

        private string _itemPrimeKey;
        private ItemData _itemData;


        private enum Images
        {
            ItemSprite
        }

        private enum GameObjects
        {
            EquipStatus
        }

        private enum Buttons
        {
            ItemBox
        }


        private void Start()
        {
            Initialized();
        }

        protected override bool Initialized()
        {
            if (!base.Initialized()) return false;

            BindButton(typeof(Buttons));
            BindImage(typeof(Images));
            BindObject(typeof(GameObjects));
            Debug.Log(ItemData.PrimeKey);
            GetImage((int)Images.ItemSprite).sprite = MainManager.ResourceManager.Load<Sprite>(ItemData.PrimeKey);;
            // GetButton((int)Buttons.ItemBox).gameObject.BindEvent(SelectItem);
            return true;
        }

        // private void SelectItem(PointerEventData obj)
        // {
        //     var inventory = PlayerInventory[_itemPrimeKey];
        //     if (inventory.IsHad)
        //     {
        //         OnUnEquipPopupOpen();
        //     }
        //     else
        //     {
        //         OnEquipPopupOpen();
        //     }
        // }
        //
        // private void OnEquipPopupOpen()
        // {
        //     MainManager.UIManager.OpenPopUp<Equipment_Popup>();
        // }
        //
        // private void OnUnEquipPopupOpen()
        // {
        //     MainManager.UIManager.OpenPopUp<UnEquipment_Popup>();
        // }
    }
}