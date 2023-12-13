using System;
using System.Collections.Generic;
using _01.Scripts.Utility;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

namespace _01.Scripts.Managers
{
    public class ResourceManager
    {
        public bool Loaded { get; set; }
        private readonly Dictionary<string, Object> _resources = new();
        private MainManager _mainManager;

        public void Initialize()
        {
            Debug.Log("리소스 매니저 초기화");
            _mainManager = ServiceLocator.GetService<MainManager>();
        }

        #region Addressables
        private void HandleCallback<T>(string key, AsyncOperationHandle<T> handle, Action<T> cb) where T : Object
        {
            handle.Completed += operationHandle =>
            {
                _resources.Add(key, operationHandle.Result);
                cb?.Invoke(operationHandle.Result);
            };
        }

        private void HandleCallback<T>(string key, AsyncOperationHandle<IList<T>> handle, Action<IList<T>> cb) where T : Object
        {
            handle.Completed += operationHandle =>
            {
                IList<T> resultList = operationHandle.Result;
                // 리스트의 각 아이템을 _resources에 추가합니다.
                for (int i = 0; i < resultList.Count; i++)
                {
                    string resourceKey = $"{key}[{i}]"; // 리스트 아이템에 대한 고유 키
                    _resources.Add(resourceKey, resultList[i]);
                }
                cb?.Invoke(resultList);
            };
        }

        private void LoadAsync<T>(string key, Action<T> cb = null) where T : Object
        {
            string loadKey = key;
            if (_resources.TryGetValue(key, out Object resource))
            {
                cb?.Invoke(resource as T);
                return;
            }

            if (key.Contains(".multiSprite"))
            {
                    AsyncOperationHandle<IList<Sprite>>handle = Addressables.LoadAssetAsync<IList<Sprite>>(loadKey);
                    HandleCallback<Sprite>(key, handle, objs => cb?.Invoke(objs as T));
            }
            else if (key.Contains(".sprite"))
            {
                // 싱글 스프라이트 처리
                AsyncOperationHandle<Sprite> handle = Addressables.LoadAssetAsync<Sprite>(loadKey);
                HandleCallback(key, handle, cb as Action<Sprite>);
            }
            else
            {
                // 일반 에셋 처리
                AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(loadKey);
                HandleCallback(key, handle, cb);
            }
        }

        public void LoadAllAsync<T>(string label, Action<string, int, int> cb)  where T : Object
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
        
        #endregion

        public T Load<T>(string key) where T : Object
        {
            Debug.Log(key);
            if (!_resources.TryGetValue(key, out var resource)) return null;
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

        public void Destroy(GameObject popupGameObject)
        {
            if (popupGameObject == null) return;
            Object.Destroy(popupGameObject);
        }

        private void Unload<T>(string key) where T : Object
        {
            if (_resources.TryGetValue(key, out var resource))
            {
                Addressables.Release(resource);
                _resources.Remove(key);
            }
            else
            {
                Debug.LogError($"Resource Unload {key}");
            }
        }
    }
}