using UnityEngine;

namespace _01.Scripts.Managers
{
    public class ObjectManager : MonoBehaviour
    {
        public void Initialized()
        {
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