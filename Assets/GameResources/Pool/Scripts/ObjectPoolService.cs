namespace FunnyBaloons.Pool
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Сервис для всех пулов
    /// </summary>
    public class ObjectPoolService
    {
        /// <summary>
        /// <item, item's pool>
        /// </summary>
        public Dictionary<GameObject, GameObjectPool> PoolsMap { get; protected set; } = new(32);

        /// <summary>
        /// <item, item's prefab>
        /// </summary>
        public Dictionary<GameObject, GameObject> SpawnedGameObjectsMap { get; protected set; } = new(256);


        /// <summary>
        /// Спаун GO
        /// </summary>
        public virtual GameObject Spawn(GameObject prefab, Transform parent)
        {
            GameObjectPool pool = GetOrCreatePool(prefab);
            GameObject instance = pool.Get();
            SpawnedGameObjectsMap.Add(instance, prefab);
            instance.transform.SetParent(parent);
            return instance;
        }

        /// <summary>
        /// Вернуть в пул
        /// </summary>
        /// <param name="instance"></param>
        public void Release(GameObject instance)
        {
            GameObject prefab = SpawnedGameObjectsMap[instance];
            GameObjectPool pool = PoolsMap[prefab];
            pool.Release(instance);
            SpawnedGameObjectsMap.Remove(instance);
        }

        /// <summary>
        /// Получить или создать пул
        /// </summary>
        public GameObjectPool GetOrCreatePool(GameObject prefab)
        {
            return PoolsMap.TryGetValue(prefab, out GameObjectPool pool)
                ? pool
                : CreatePool(prefab);
        }

        /// <summary>
        /// Создать пул
        /// </summary>
        public GameObjectPool CreatePool(GameObject prefab)
        {
#if UNITY_EDITOR
            if (PoolsMap.ContainsKey(prefab))
            {
                Debug.LogError($"The pool with prefab '{prefab.name}' already exists!");
            }
#endif
            var newPool = new GameObjectPool(prefab);
            PoolsMap.Add(prefab, newPool);
            return newPool;
        }
    }
}