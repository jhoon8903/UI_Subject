using System;
using System.IO;
using System.Linq;
using _01.Scripts.Data;
using _01.Scripts.Interfaces;
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
            CreateData<ItemDataLoader, ItemData>();
            CreateData<CharacterDataLoader, CharacterData>();
            CreateData<JobDataLoader, JobData>();
        }

        private static void CreateData<T, TValue>() where T : ILoader<string, TValue>, new()
        {
            T loader = new T();
            string typeName = typeof(TValue).Name;
            string[] lines = File.ReadAllText($"{CsvFilePath}/{typeName}.csv").Split("\n");
            for (int i = 1; i < lines.Length; i++)
            {
                string[] row =  lines[i].Replace("\n", "").Split(',');
                if (row.Length == 0 || string.IsNullOrEmpty(row[0])) continue;
                MappingData<T, TValue>(row, loader);
            }
            string jsonFile = JsonConvert.SerializeObject(loader, Formatting.Indented);
            File.WriteAllText($"{JsonFilePath}/{typeName}.json",jsonFile);
        }

        private static void MappingData<T, TValue>(string[] row, T loader) where T : ILoader<string, TValue>
        {
            loader.MapData(row);
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
#endif
    }
}