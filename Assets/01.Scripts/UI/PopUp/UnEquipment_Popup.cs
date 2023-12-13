using System;
using System.Linq;
using _01.Scripts.Data;
using _01.Scripts.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _01.Scripts.UI.PopUp
{
    public class UnEquipment_Popup : UIPopup
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

        private void Start()
        {
            Initialized();
        }

        protected override bool Initialized()
        {
            if (!base.Initialized()) return false;
            BindButton(typeof(Buttons));
            GetButton((int)Buttons.ConfirmBtn).gameObject.BindEvent(OnUnEquipment);
            GetButton((int)Buttons.CancelBtn).gameObject.BindEvent(ClosePopUp);
            return true;
        }

        private void OnUnEquipment(PointerEventData obj)
        {
            var inventory = Player.Inventory.FirstOrDefault(dict => dict.ContainsKey(_itemData.PrimeKey));
            if (inventory != null && !inventory[_itemData.PrimeKey].IsEquipment)
            {
                inventory[_itemData.PrimeKey].IsEquipment = false;
            }
            EventManager.RefreshEvent();
            MainManager.UIManager.ClosePopUp();
        }
    }
}