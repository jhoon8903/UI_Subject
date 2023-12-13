using System;
using _01.Scripts.Managers;
using _01.Scripts.UI.PopUp;
using UnityEngine.EventSystems;

namespace _01.Scripts.UI.Scene
{
    public class UISceneMain : UIScene
    {
        private enum Buttons
        {
            StatusBtn,
            InventoryBtn,
            StoreBtn
        }

        protected void Start()
        {
            Initialized();
        }

        protected override bool Initialized()
        {
            if (!base.Initialized()) return false;
            BindButton(typeof(Buttons));
            GetButton((int)Buttons.StatusBtn).gameObject.BindEvent(OpenStatusBtn);
            GetButton((int)Buttons.InventoryBtn).gameObject.BindEvent(OpenInventory);
            GetButton((int)Buttons.StoreBtn).gameObject.BindEvent(OpenStore);
            return true;
        }

        private void OpenStatusBtn(PointerEventData data)
        {
            MainManager.UIManager.OpenPopUp<Status_Popup>();
        }

        private void OpenInventory(PointerEventData data)
        {
            MainManager.UIManager.OpenPopUp<Inventory_Popup>();
        }

        private void OpenStore(PointerEventData data)
        {
            MainManager.UIManager.OpenPopUp<Store_Popup>();
        }
    }
}