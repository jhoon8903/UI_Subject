using _01.Scripts.UI.Base;

namespace _01.Scripts.UI.Scene
{
    public class UIScene : UIBase
    {
        protected override bool Initialized()
        {
            if (!base.Initialized()) return false;
            MainManager.UIManager.SetCanvas(gameObject, false);
            return true;
        }
    }
}