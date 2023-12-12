using System;
using _01.Scripts.UI.Scene;

namespace _01.Scripts.Scenes
{
    public class MainScene  : BaseScene
    {
        protected override bool Initialize()
        {
            if (!base.Initialize()) return false;
            MainManager.UIManager.ShowSceneUI<UISceneMain>();
            return true;
        }
    }
}