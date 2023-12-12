using System;
using _01.Scripts.Scenes;
using _01.Scripts.Utility;
using UnityEngine;

namespace _01.Scripts.Managers
{
    public class MainManager : MonoBehaviour 
    {
        private void Awake()
        {
            ServiceLocator.RegisterService(this);
        }

        public void Initialize()
        {
            ObjectManager.Initialized();
            ResourceManager.Initialize();
            UIManager.Initialize();
            DataManager.Initialize();
        }

        public ResourceManager ResourceManager { get; set; } = new();
        public ObjectManager ObjectManager { get; set; } = new();
        public UIManager UIManager { get; set; } = new();
        public DataManager DataManager { get; set; } = new();

        public void Clear()
        {

        }
    }
}