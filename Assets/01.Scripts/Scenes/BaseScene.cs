using _01.Scripts.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _01.Scripts.Scenes
{
    public class BaseScene : MonoBehaviour
    {
        protected MainManager MainManager;
        private bool _initialized = false;
        private void Start()
        {
            if (MainManager.ResourceManager.Loaded)
            {
                Initialize();
            }
            else
            {
                MainManager.ResourceManager.LoadAllAsync<Object>("PreLoad", (key, count, totalCount) =>
                {
                    if (count < totalCount) return;
                    MainManager.ResourceManager.Loaded = true;
                    Initialize();
                });
            }
        }

        protected virtual bool Initialize()
        {
            if (_initialized) return false;
            _initialized = true;
            Object obj = FindObjectOfType<EventSystem>();
            if (obj == null)
            {
                MainManager.ResourceManager.InstantiatePrefab("EventSystem.prefab").name = "@EventSystem";
            }
            MainManager.Initialize();
            return _initialized;
        }
    }
}