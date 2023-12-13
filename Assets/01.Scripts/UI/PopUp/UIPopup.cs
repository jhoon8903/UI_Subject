using _01.Scripts.UI.Base;
using _01.Scripts.UI.Scene;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _01.Scripts.UI.PopUp
{
    public class UIPopup : UIBase
    {
        protected override bool Initialized()
        {
            if (!base.Initialized()) return false;
            MainManager.UIManager.SetCanvas(gameObject, true);
            return true;
        }

        protected virtual void ClosePopUp(PointerEventData data)
        {
         
            MainManager.UIManager.ClosePopUp();
        }
    }
}