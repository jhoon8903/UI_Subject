using System;
using System.Collections.Generic;
using System.Linq;
using _01.Scripts.Data;
using _01.Scripts.Managers;
using _01.Scripts.Utility;
using UnityEngine;
using Random = System.Random;

namespace _01.Scripts.Characters
{
    public class Player : MonoBehaviour
    {
        private MainManager _mainManager;
        public string CharacterName { get; set; } = "Chad";
        public int Gold { get; set; } = 10000;
        public int Level { get; set; } = 10;
        public int Exp { get; set; } = 47;
        public int MaxHp { get; set; } = 100;
        public List<Dictionary<string, Inventory>> Inventory { get; set; } = new();

        private void Start()
        {
            ServiceLocator.RegisterService(this);
            Debug.Log("플레이어 등록");
            _mainManager = ServiceLocator.GetService<MainManager>();
            InventoryTestSetting();
        }

        private void InventoryTestSetting()
        {
           var itemList =  _mainManager.DataManager.Items.Values.ToList();
           Random random = new Random();
           List<ItemData> selectItemList = new List<ItemData>();

           while (selectItemList.Count < 5 && itemList.Count > 0)
           {
               int index = random.Next(itemList.Count);
               selectItemList.Add(itemList[index]);
               itemList.RemoveAt(index);
           }

           foreach (var inventoryItem in selectItemList.Select(item => new Dictionary<string, Inventory> 
                    {
                        {
                            item.PrimeKey, new Inventory
                            {
                                IsEquipment = false, IsHad = true
                            }
                        }
                    }))
           {
               Inventory.Add(inventoryItem); 
           }
        }

        private void BuyItem(string key)
        {

        }
    }
}