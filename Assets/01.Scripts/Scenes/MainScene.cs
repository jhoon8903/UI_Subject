using System;
using _01.Scripts.UI.Scene;
using UnityEngine;

namespace _01.Scripts.Scenes
{
    public class MainScene  : BaseScene
    {
        protected override bool Initialize()
        {
            if (!base.Initialize()) return false;
            MainManager.UIManager.ShowSceneUI<UISceneMain>();
            MainManager.ResourceManager.InstantiatePrefab("BackGround.prefab").name = "@BackGround";
            MainManager.ResourceManager.InstantiatePrefab("Player.prefab").name = "@Player";
            return true;
        }
    }
}