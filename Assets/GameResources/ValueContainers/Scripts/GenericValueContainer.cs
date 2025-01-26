namespace FunnyBaloons.ValueContainers
{
    using System;
    using System.IO;
    using UnityEngine;

    /// <summary>
    /// Контейнер для сохранения данных в файл
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericValueContainer<T> : ScriptableObject
    {
        /// <summary>
        /// Изменилось значение
        /// </summary>
        public event Action OnValueChanged = delegate { };

        /// <summary>
        /// Значение
        /// </summary>
        public T Data
        {
            get
            {
                LoadFromFile();
                return data;
            }

            set
            {
                data = value;
                SaveToFile();
                OnValueChanged();
            }
        }

        [SerializeField]
        protected string fileName = "SaveFileName";

        [SerializeField]
        private T data = default;

        protected virtual void SaveToFile()
        {
            string json = JsonUtility.ToJson(this);
            string path = Path.Combine(Application.persistentDataPath, fileName);
            File.WriteAllText(path, json);
            Debug.Log($"Data saved to {path}");
        }

        protected virtual void LoadFromFile()
        {
            string path = Path.Combine(Application.persistentDataPath, fileName);
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                JsonUtility.FromJsonOverwrite(json, this);
                Debug.Log($"Data loaded from {path}");
            }
            else
            {
                Debug.LogWarning($"File not found: {path}");
            }
        }
    }
}