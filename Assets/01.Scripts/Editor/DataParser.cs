using System;
using System.IO;
using _01.Scripts.Data;
using _01.Scripts.Loader;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace _01.Scripts.Editor
{
    public class DataParser : EditorWindow
    {
#if UNITY_EDITOR
        private static readonly string CsvFilePath = $"{Application.dataPath}/03.Resources/@CsvData";
        private static readonly string JsonFilePath = $"{Application.dataPath}/03.Resources/@JsonData";
        #region CreateJsonData

        [MenuItem("Tools/CreateJSON")]
        public static void CreateJsonFile()
        {
            CreateData<ItemDataLoader>("ItemData");
            CreateData<CharacterDataLoader>("CharacterData");
            CreateData<JobDataLoader>("JobData");
        }

        private static void CreateData<T>(string csvFileName) where T : new()
        {
            T loader = new();
            string[] lines = File.ReadAllText($"{CsvFilePath}/{csvFileName}.csv").Split("\n");
            for (int i = 1; i < lines.Length; i++)
            {
                string[] row =  lines[i].Replace("\n", "").Split(',');
                if (row.Length == 0 || string.IsNullOrEmpty(row[0])) continue;
                MappingData(csvFileName, row, loader);
            }
            string jsonFile = JsonConvert.SerializeObject(loader, Formatting.Indented);
            File.WriteAllText($"{JsonFilePath}/{csvFileName}.json",jsonFile);
        }

        private static void MappingData<T>(string csvFileName, string[] row, T loader) where T : new()
        {
            switch (csvFileName)
            {
                case "ItemData":
                    ItemData(row,loader as ItemDataLoader);
                    break;
                case "JobData":
                    JobData(row, loader as JobDataLoader);
                    break;
                case "CharacterData":
                    CharacterData(row, loader as CharacterDataLoader);
                    break;
            }
        }

        #endregion

        #region DeleteJsonData

        [MenuItem("Tools/DeleteSaveJSON")]
        public static void DeleteJsonFile()
        {
            PlayerPrefs.DeleteAll();
            string path = Application.persistentDataPath + "/SaveData.json";
            if (File.Exists(path)) File.Delete(path);
        }
    
        #endregion

        #region ItemData

        private static void ItemData(string[] row, ItemDataLoader loader)
        { 
            loader.items.Add(new ItemData
            {
                PrimeKey = row[0],
                Name = row[1],
                Type = (Itemtypes)Enum.Parse(typeof(Itemtypes),row[2]),
                Attribute = int.Parse(row[3]),
                Price = int.Parse(row[4])
            });
        } 
        #endregion

        #region CharacterData

        private static void CharacterData(string[] row, CharacterDataLoader loader)
        {
            loader.character.Add(new CharacterData
            {
                PrimeKey = row[0],
                Name = row[1],
                JobClass = (JobClass)Enum.Parse(typeof(JobClass),row[2]),
                Level = int.Parse(row[3]), 
                Damage = int.Parse(row[4]),
                Defense = int.Parse(row[5]), 
                CriticalRate = int.Parse(row[6]), 
                Inventory = null
            });
        }

        #endregion

        #region JobData

        private static void JobData(string[] row, JobDataLoader loader)
        {
            loader.jobs.Add(new JobData
            {
                JobClass = (JobClass)Enum.Parse(typeof(JobClass), row[0]),
                Desc = row[1]
            });
        }

        #endregion

#endif
    }
}