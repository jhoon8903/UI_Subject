using System;
using _01.Scripts.Managers;
using _01.Scripts.UI.PopUp;
using _01.Scripts.Utility;
using UnityEngine;
using UnityEngine.EventSystems;
using Object = UnityEngine.Object;

namespace _01.Scripts.Scenes
{
    public class BaseScene : MonoBehaviour
    {
        protected MainManager MainManager;
        private bool _initialized = false;
        private Intro_Popup _loading;

        private void Start()
        {
            _loading = FindObjectOfType<Intro_Popup>();
            LoadAddressable();
        }

        protected virtual void LoadAddressable()
        {
            MainManager = ServiceLocator.GetService<MainManager>();
            if (MainManager.ResourceManager.Loaded)
            {
                Initialize();
            }
            else
            {
                MainManager.ResourceManager.LoadAllAsync<Object>("PreLoad", (key, count, totalCount) =>
                {
                    Debug.Log($"{key} Load ({count} / {totalCount})");
                    _loading.Count = count;
                    _loading.MaxCount = totalCount;
                    _loading.Loading(key);

                    if (count < totalCount) return;
                    MainManager.ResourceManager.Loaded = true;
                    
                    Initialize();
                });
            }
        }

        protected virtual bool Initialize()
        {
            if (_initialized) return false;
            Destroy(_loading.gameObject);
            _initialized = true;
            Object obj = FindObjectOfType<EventSystem>();
            MainManager.Initialize();
            if (obj != null) return _initialized;
            MainManager.ResourceManager.InstantiatePrefab("EventSystem.prefab").name = "@EventSystem";
            return _initialized;
        }
    }
}