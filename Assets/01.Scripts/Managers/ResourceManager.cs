using System;
using System.Collections.Generic;
using _01.Scripts.Utility;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace _01.Scripts.Managers
{
    public class ResourceManager
    {
        public bool Loaded { get; set; }
        private Dictionary<string, UnityEngine.Object> _resources = new();
        private MainManager _mainManager;

        public void Initialize()
        {
            _mainManager = ServiceLocator.GetService<MainManager>();
        }

        private void HandleCallback<T>(string key, AsyncOperationHandle<T> handle, Action<T> cb) where T : UnityEngine.Object
        {
            handle.Completed += handle =>
            {
                _resources.Add(key, handle.Result);
                cb?.Invoke(handle.Result);
            };
        }

        public void LoadAsync<T>(string key, Action<T> cb = null) where T : UnityEngine.Object
        {
            if (_resources.TryGetValue(key, out UnityEngine.Object resource))
            {
                cb?.Invoke(resource as T);
                return;
            }
            string loadKey = key;
            if (key.Contains(".sprite"))
            {
                loadKey = $"{key}[{key.Replace(".sprite", "")}]";
            }

            if (key.Contains(".sprite"))
            {
                AsyncOperationHandle<Sprite> handle = Addressables.LoadAssetAsync<Sprite>(loadKey);
                HandleCallback(key, handle, cb as Action<Sprite>);
            }
            else
            {
                AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(loadKey);
                HandleCallback(key, handle, cb);
            }
        }

        public void LoadAsync<T>(string label, Action<string, int, int> cb)  where T : UnityEngine.Object
        {
            var operation = Addressables.LoadResourceLocationsAsync(label, typeof(T));
            operation.Completed += op =>
            {
                int loadCount = 0;
                int totalCount = op.Result.Count;
                foreach (var result in op.Result)
                {
                    LoadAsync<T>(result.PrimaryKey, obj =>
                    {
                        loadCount++;
                        cb?.Invoke(result.PrimaryKey, loadCount, totalCount);
                    });
                }
            };
            Loaded = true;
        }

        public T Load<T>(string key) where T : UnityEngine.Object
        {
            if (!_resources.TryGetValue(key, out UnityEngine.Object resource)) return null;
            return resource as T;
        }

        public GameObject InstantiatePrefab(string key, Transform parent = null)
        {
            GameObject prefab = Load<GameObject>(key);
            if (prefab == null)
            {
                Debug.LogError($"[ResourceManager] Instantiate({key}): Failed to load prefab.");
            }
            return InstantiateEvent(prefab, parent);
        }

        private GameObject InstantiateEvent(GameObject prefab, Transform parent)
        {
            return EventManager.OnInstantiate(prefab, parent);
        }
    }
}