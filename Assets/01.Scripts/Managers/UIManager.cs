using System.Collections.Generic;
using _01.Scripts.UI.PopUp;
using _01.Scripts.UI.Scene;
using _01.Scripts.Utility;
using UnityEngine;

namespace _01.Scripts.Managers
{
    public class UIManager
    {
        private int _sortOrderNumber = 1;
        private Stack<UIPopup> _popupStack = new();
        private UIScene _uiScene = null;
        private MainManager _mainManager;

        public void Initialize()
        {
            Debug.Log("UI 매니저 초기화");
            _mainManager = ServiceLocator.GetService<MainManager>();
        }

        private GameObject Root
        {
            get
            {
                GameObject root = GameObject.Find("@UIRoot");
                if (root == null)
                {
                    root = new GameObject { name = "@UIRoot" };
                }
                return root;
            }
        }

        public T OpenPopUp<T>(string name = null) where T : UIPopup
        {
            if (string.IsNullOrEmpty(name))
            {
                name = typeof(T).Name;
            }

            GameObject gameObject = _mainManager.ResourceManager.InstantiatePrefab($"{name}.prefab");
            T popup = UtilityToGetAddComponent.GetOrAddComponent<T>(gameObject);
            _popupStack.Push(popup);
            gameObject.transform.SetParent(Root.transform);
            // RefreshTimeScale();
            return popup;
        }

        public void ClosePopUp()
        {
            Debug.Log("닫기");
            if (_popupStack.Count == 0) return;
            UIPopup popup = _popupStack.Pop();
            _mainManager.ResourceManager.Destroy(popup.gameObject);
            _sortOrderNumber--;
        }

        public void CloseAllPopup()
        {
            while (_popupStack.Count> 0)
            {
                ClosePopUp();
            }
        }

        public void SetCanvas(GameObject gameObject, bool sort = true)
        {
            Canvas canvas = UtilityToGetAddComponent.GetOrAddComponent<Canvas>(gameObject);
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.overrideSorting = true;
            if (sort)
            {
                canvas.sortingOrder = _sortOrderNumber;
                _sortOrderNumber++;
            }
            else
            {
                canvas.sortingOrder = 0;
            }
        }

        public T ShowSceneUI<T>(string name = null) where T : UIScene
        {
            if (string.IsNullOrEmpty(name)) name = typeof(T).Name;
            GameObject gameObject = _mainManager.ResourceManager.InstantiatePrefab($"{name}.prefab");
            T sceneUI = UtilityToGetAddComponent.GetOrAddComponent<T>(gameObject);
            _uiScene = sceneUI;
            gameObject.transform.SetParent(Root.transform);
            return sceneUI;
        }

        private void RefreshTimeScale()
        {
            Time.timeScale = _popupStack.Count > 0 ? 0 : 1;
        }
    }
}