using System;
using _01.Scripts.Managers;
using _01.Scripts.UI.SubItem;

namespace _01.Scripts.UI.PopUp
{
    public class Store_Popup : UIPopup
    {
        private enum Buttons
        {
            CloseBtn
        }

        private enum GameObjects
        {
            Content
        }

        private void Start()
        {
            Initialized();
        }

        protected override bool Initialized()
        {
            if (!base.Initialized()) return false;
            BindButton(typeof(Buttons));
            // GetButton((int)Buttons.CloseBtn).gameObject.BindEvent(ClosePopUp);
            return true;
        }

        private void InstantiateStoreItems()
        {
            foreach (var key in MainManager.DataManager.Items.Keys)
            {
            }
        }
    }
}