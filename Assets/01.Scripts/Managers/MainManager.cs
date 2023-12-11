using System;
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

        private void Start()
        {
            ObjectManager.Initialized();
            ResourceManager.Initialize();
        }

        public ResourceManager ResourceManager { get; set; } = new();
        public ObjectManager ObjectManager { get; set; } = new();
    }
}