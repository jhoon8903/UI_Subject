using _01.Scripts.Managers;
using _01.Scripts.UI.SubItem;
using UnityEngine;
using UnityEngine.EventSystems;

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

        // protected override bool Initialized()
        // {
        //     if (!base.Initialized()) return false;
        //     BindButton(typeof(Buttons));
        //     GetButton((int)Buttons.ReturnBtn).gameObject.BindEvent(ClosePanel);
        //     SetInventory();
        //
        // }

        private void SetInventory()
        {
            foreach (string key in MainManager.DataManager.Items.Keys)
            {
                ItemBox itemBox = MainManager.ResourceManager.InstantiatePrefab("ItemBox.prefab", GetObject((int)GameObjects.Content).transform).GetComponent<ItemBox>();

            }
        }

        // private void SetupItem(string key)
        // {
        //     if (MainManager.DataManager.Character)
        //     {
        //
        //     }
        // }

        private void ClosePanel(PointerEventData obj)
        {
        }
    }
}