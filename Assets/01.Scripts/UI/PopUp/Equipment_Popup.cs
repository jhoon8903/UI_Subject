using System;
using System.Linq;
using _01.Scripts.Data;
using _01.Scripts.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _01.Scripts.UI.PopUp
{
    public class Equipment_Popup : UIPopup
    {
        public ItemData ItemData
        {
            get => _itemData;
            set
            {
                _itemData = value;
                Debug.Log(_itemData);
            }
        }

        private ItemData _itemData;

        private enum Buttons
        {
            CancelBtn,
            ConfirmBtn
        }

        private enum Images
        {
            ItemSprite,
            ItemTypeIcon
        }

        private enum Texts
        {
            ItemName,
            ItemDesc,
            ItemTypeText,
            ItemStatusText
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
            BindText(typeof(Texts));
            GetButton((int)Buttons.ConfirmBtn).gameObject.BindEvent(OnEquipment);
            GetButton((int)Buttons.CancelBtn).gameObject.BindEvent(ClosePopUp);
            Setup();
            return true;
        }

        private void Setup()
        {
            GetImage((int)Images.ItemSprite).sprite = MainManager.ResourceManager.Load<Sprite>($"{_itemData.PrimeKey}.sprite");
            GetText((int)Texts.ItemName).text = $"{_itemData.PrimeKey}";
            GetText((int)Texts.ItemDesc).text = $"{_itemData.Desc}";
            GetText((int)Texts.ItemStatusText).text = $"{_itemData.Attribute}";
            GetText((int)Texts.ItemTypeText).text = $"{_itemData.AttributeType}";
        }

        private void OnEquipment(PointerEventData obj)
        {
            var inventory = Player.Inventory.FirstOrDefault(dict => dict.ContainsKey(_itemData.PrimeKey));
            if (inventory != null && !inventory[_itemData.PrimeKey].IsEquipment)
            {
                inventory[_itemData.PrimeKey].IsEquipment = true;
            }
            EventManager.RefreshEvent();
            MainManager.UIManager.ClosePopUp();
        }
    }
}