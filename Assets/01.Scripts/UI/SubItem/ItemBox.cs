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
            GetObject((int)GameObjects.EquipStatus).gameObject.SetActive(false);
            return true;
        }

        private void SelectItem(PointerEventData obj)
        {
            var inventory = Player.Inventory.FirstOrDefault(dict => dict.ContainsKey(_itemPrimeKey));
           
            if (inventory != null && inventory[_itemPrimeKey].IsHad)
            {
                OnUnEquipPopupOpen();
            }
            else
            {
                OnEquipPopupOpen();
            }
        }

        private void OnEquipPopupOpen()
        {
            MainManager.UIManager.OpenPopUp<Equipment_Popup>();
        }
        
        private void OnUnEquipPopupOpen()
        {
            MainManager.UIManager.OpenPopUp<UnEquipment_Popup>();
        }
    }
}