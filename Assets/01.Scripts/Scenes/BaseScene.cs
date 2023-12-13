using _01.Scripts.Managers;
using _01.Scripts.UI.PopUp;
using _01.Scripts.Utility;
using UnityEngine;
using UnityEngine.EventSystems;
using Object = UnityEngine.Object;
using System.Collections;

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

        private void LoadAddressable()
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
                    StartCoroutine(UpdateLoadingUI(key, count, totalCount));
                });
            }
        }

        private IEnumerator UpdateLoadingUI(string key, int count, int totalCount)
        {
            // UI 업데이트 로직
            _loading.Count = count;
            _loading.MaxCount = totalCount;
            _loading.Loading(key);
            Debug.Log($"{key} Load ({count} / {totalCount})");

            // 0.1초 대기
            yield return new WaitForSeconds(0.1f);

            // 모든 에셋이 로드되면 초기화 호출
            if (count < totalCount) yield break;
            MainManager.ResourceManager.Loaded = true;
            Initialize();
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