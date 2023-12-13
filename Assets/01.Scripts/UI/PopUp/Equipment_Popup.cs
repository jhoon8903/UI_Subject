using System;
using _01.Scripts.Managers;
using UnityEngine;

namespace _01.Scripts.UI.PopUp
{

    public class Equipment_Popup : UIPopup
    {
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

        protected override bool Initialized()
        {
            BindButton(typeof(Buttons));
            BindImage(typeof(Images));
            BindText(typeof(Texts));

            GetButton((int)Buttons.ConfirmBtn).gameObject.BindEvent();
            GetButton((int)Buttons.CancelBtn).gameObject.BindEvent();

            return true;
        }
    }
}