using System.Linq;
using UnityEngine;

namespace _01.Scripts.Utility
{
    public class UtilityToFindObject
    {
        public static T ComponentFormFindChild<T>(GameObject findObject, string name = null, bool recursive = false) where T : Object
        {
            if (findObject == null) return null;

            if (!recursive)
            {
                for (int i = 0; i < findObject.transform.childCount; i++)
                {
                    Transform findObjectTransform = findObject.transform.GetChild(i);
                    if (!string.IsNullOrEmpty(name)) continue;
                    T component = findObjectTransform.GetComponent<T>();
                    if (component != null) return component;
                }
            }
            else
            {
                return findObject.GetComponentsInChildren<T>()
                    .FirstOrDefault(component => string.IsNullOrEmpty(name) || component.name == name);
            }
            return null;
        }

        public static GameObject NoneComponentFormFindChildren(GameObject findObject, string name = null, bool recursive = false)
        {
            Transform findObjectTransform = ComponentFormFindChild<Transform>(findObject, name, recursive);
            return findObjectTransform == null ? null : findObjectTransform.gameObject;
        }
    }
}