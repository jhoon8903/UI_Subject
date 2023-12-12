using _01.Scripts.UI.Base;
using _01.Scripts.UI.Scene;

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

        public virtual void ClosePanel()
        {
            MainManager.UIManager.ClosePopUp(this);
        }
    }
}