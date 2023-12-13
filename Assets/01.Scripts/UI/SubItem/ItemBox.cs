using System.Linq;
using _01.Scripts.Data;
using _01.Scripts.Managers;
using _01.Scripts.UI.Base;
using _01.Scripts.UI.PopUp;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _01.Scripts.UI.SubItem
{
    public class ItemBox : UIBase
    {
        private MainManager _mainManager;
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

        public bool Equipment
        {
            get
            {
                var inventory = Player.Inventory.FirstOrDefault(dict => dict.ContainsKey(_itemPrimeKey));
                return inventory != null && inventory[_itemPrimeKey].IsEquipment;
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
            GetImage((int)Images.ItemSprite).sprite = MainManager.ResourceManager.Load<Sprite>($"{ItemData.PrimeKey}.sprite");
            GetButton((int)Buttons.ItemBox).gameObject.BindEvent(SelectItem);
            GetObject((int)GameObjects.EquipStatus).gameObject.SetActive(Equipment);
            EventManager.OnResoruceChanged -= OnEquipmentIcon;
            EventManager.OnResoruceChanged += OnEquipmentIcon;
            OnEquipmentIcon();
            return true;
        }


        private void SelectItem(PointerEventData obj)
        {
            var inventory = Player.Inventory.FirstOrDefault(dict => dict.ContainsKey(_itemPrimeKey));
           
            if (inventory != null && inventory[_itemPrimeKey].IsEquipment)
            {
                OnUnEquipPopupOpen();
            }
            else
            {
                OnEquipPopupOpen();
            }
        }

        private void OnEquipmentIcon()
        {
            Initialized();
            Debug.Log(Equipment);
        }

        private void OnEquipPopupOpen()
        {
            var popup = MainManager.UIManager.OpenPopUp<Equipment_Popup>();
            popup.ItemData = _itemData;
        }
        
        private void OnUnEquipPopupOpen()
        {
            var popup = MainManager.UIManager.OpenPopUp<UnEquipment_Popup>();
            popup.ItemData = _itemData;
        }
    }
}