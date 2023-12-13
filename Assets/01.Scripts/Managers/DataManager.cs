using System.Collections.Generic;
using _01.Scripts.Data;
using _01.Scripts.Utility;
using _01.Scripts.Interfaces;
using _01.Scripts.Loader;
using Newtonsoft.Json;
using UnityEngine;

namespace _01.Scripts.Managers
{
    public class DataManager
    {
        private MainManager _mainManager;
        public Dictionary<string, ItemData> Items = new();
        public Dictionary<string, JobData> Jobs = new();
        public Dictionary<string, CharacterData> Character = new();

        public void Initialize()
        {
            Debug.Log("데이터 매니저 초기화");
            _mainManager = ServiceLocator.GetService<MainManager>();
            Items = LoadJson<ItemDataLoader, string, ItemData>("ItemData").CreateData();
            Jobs = LoadJson<JobDataLoader, string, JobData>("JobData").CreateData();
            Character = LoadJson<CharacterDataLoader, string, CharacterData>("CharacterData").CreateData();
        }

        private TLoader LoadJson<TLoader, TKey, TValue>(string path) where TLoader : ILoader<TKey, TValue>
        {
            TextAsset textAsset = _mainManager.ResourceManager.Load<TextAsset>(path);
            return JsonConvert.DeserializeObject<TLoader>(textAsset.text);
        }

        public void SetUpItemData(string key)
        {
            var itemSprite = _mainManager.ResourceManager.Load<Sprite>(key);

        }
    }
}