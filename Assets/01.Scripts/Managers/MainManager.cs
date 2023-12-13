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
            Debug.Log("메인 매니저 초기화");
            ObjectManager.Initialized();
            ResourceManager.Initialize();
            UIManager.Initialize();
            DataManager.Initialize();
        }

        public ResourceManager ResourceManager { get; } = new();
        public ObjectManager ObjectManager { get; } = new();
        public UIManager UIManager { get; } = new();
        public DataManager DataManager { get; } = new();

        public void Clear()
        {

        }
    }
}