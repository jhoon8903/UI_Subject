using System;
using System.Collections.Generic;
using _01.Scripts.Characters;
using _01.Scripts.Managers;
using _01.Scripts.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace _01.Scripts.UI.Base
{
    public class UIBase : MonoBehaviour
    {
        private bool _initialized;
        protected Dictionary<Type, Object[]> UIObjects = new();
        protected MainManager MainManager;
        protected Player Player;
        protected event Action OnEquipChanged; 
        protected virtual bool Initialized()
        {
            if (_initialized) return false;
            _initialized = true;
            MainManager = ServiceLocator.GetService<MainManager>();
            Player = ServiceLocator.GetService<Player>();
            return _initialized;
        }

        #region Bind Property
        protected void BindObject(Type type) => Bind<GameObject>(type);
        protected void BindText(Type type) => Bind<TextMeshProUGUI>(type);
        protected void BindButton(Type type) => Bind<Button>(type);
        protected void BindImage(Type type) => Bind<Image>(type);
        #endregion

        #region Bind Method
        protected GameObject GetObject(int objectIndex ) { return GetUIObject<GameObject>(objectIndex); }
        protected TextMeshProUGUI GetText(int objectIndex) { return GetUIObject<TextMeshProUGUI>(objectIndex); }
        protected Button GetButton(int objectIndex) { return GetUIObject<Button>(objectIndex); }
        protected Image GetImage(int objectIndex) { return GetUIObject<Image>(objectIndex); }
        #endregion

        #region Bind Setup
        protected void Bind<T>(Type type) where T : Object
        {
            string[] names = Enum.GetNames(type);
            Object[] objects = new Object[names.Length];
            UIObjects.Add(typeof(T), objects);

            for (int i = 0; i < names.Length; i++)
            {
                objects[i] = typeof(T) == typeof(GameObject)
                    ? UtilityToFindObject.NoneComponentFormFindChildren(gameObject, names[i], true)
                    : UtilityToFindObject.ComponentFormFindChild<T>(gameObject, names[i], true);
                if (objects[i] == null) Debug.LogWarning($"Failed to bind({names[i]})");
            }
        }

        protected T GetUIObject<T>(int objectIndex) where T : Object
        {
            if (!UIObjects.TryGetValue(typeof(T), out Object[] objects)) return null;
            return objects[objectIndex] as T;
        }
        #endregion

        protected virtual void OnOnEquipChanged()
        {
            OnEquipChanged?.Invoke();
        }
    }                                                              
}