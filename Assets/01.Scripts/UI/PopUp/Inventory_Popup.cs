using System.Collections.Generic;
using System.Linq;
using _01.Scripts.Characters;
using _01.Scripts.Data;
using _01.Scripts.Managers;
using _01.Scripts.UI.SubItem;
using _01.Scripts.Utility;

namespace _01.Scripts.UI.PopUp
{
    public class Inventory_Popup  : UIPopup
    {
        private enum Buttons
        {
            ReturnBtn,
        }

        private enum GameObjects
        {
            Content
        }

        protected List<Dictionary<string, Inventory>> PlayerInventory;
        private Player _player;
        private void Start()
        {
            Initialized();
        }

        protected override bool Initialized()
        {
            if (!base.Initialized()) return false;
            BindButton(typeof(Buttons)); 
            BindObject(typeof(GameObjects));
            GetButton((int)Buttons.ReturnBtn).gameObject.BindEvent(ClosePopUp);
            _player = ServiceLocator.GetService<Player>();
            SetInventory();
            return true;
        }

        private void SetInventory()
        {
            PlayerInventory = _player.Inventory;
            foreach (var pairValue in PlayerInventory.SelectMany(inventory => inventory.Where(pairValue => pairValue.Value.IsHad)))
            {
                if (!MainManager.DataManager.Items.TryGetValue(pairValue.Key, out var itemData)) continue;
                ItemBox itemBox = MainManager.ResourceManager.InstantiatePrefab("ItemBox.prefab", GetObject((int)GameObjects.Content).transform).GetComponent<ItemBox>();
                itemBox.ItemData = itemData;
            }
        }
    }
}