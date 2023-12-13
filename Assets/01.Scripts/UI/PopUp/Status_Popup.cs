using System;
using _01.Scripts.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _01.Scripts.UI.PopUp
{
    public class Status_Popup : UIPopup
    {
        private enum Buttons
        {
            ReturnBtn
        }

        private void Start()
        {
            Initialized();
        }
        protected override bool Initialized()
        {
            if (!base.Initialized()) return false;
            BindButton(typeof(Buttons));
            GetButton((int)Buttons.ReturnBtn).gameObject.BindEvent(ClosePopUp);
            return true;
        }
    }
}