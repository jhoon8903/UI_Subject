using UnityEngine;

namespace _01.Scripts.Utility
{
    public class UtilityToGetAddComponent
    {
        public static T GetOrAddComponent<T>(GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponent<T>();
            if (component == null)
            {
                component = gameObject.AddComponent<T>();
            }
            return component;
        }
    }
}