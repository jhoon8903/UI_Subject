using _01.Scripts.Characters;
using UnityEngine;

namespace _01.Scripts.Managers
{
    public class ObjectManager : MonoBehaviour
    {
        public void Initialized()
        { 
            Debug.Log("오브젝트 매니저 초기화");
            EventManager.OnInstantiatePrefab += InstantiateGameObject;
        }

        private GameObject InstantiateGameObject(GameObject prefab, Transform parentTransform)
        {
            GameObject obj = Instantiate(prefab, parentTransform);
            obj.name = prefab.name;
            return obj;
        }
    }
}