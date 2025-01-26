namespace FunnyBaloons.Pool
{
    using System;
    using UnityEngine;
    using UnityEngine.Pool;
    using Object = UnityEngine.Object;

    /// <summary>
    /// Пул для GO 
    /// </summary>
    public class GameObjectPool : IDisposable
    {
        protected GameObject prefab = default;
        protected ObjectPool<GameObject> pool = default;

        public GameObjectPool(GameObject spawnPrefab)
        {
            prefab = spawnPrefab;
            pool = new ObjectPool<GameObject>(CreateItem, OnGet, OnRelease, OnDestroy);
        }

        protected virtual GameObject CreateItem() => Object.Instantiate(prefab);

        protected virtual void OnGet(GameObject item) => item.gameObject.SetActive(true);

        protected virtual void OnRelease(GameObject item) => item.gameObject.SetActive(false);

        protected virtual void OnDestroy(GameObject item) => Object.Destroy(item);


        /// <summary>
        /// Получить объект из пула
        /// </summary>
        /// <returns></returns>
        public virtual GameObject Get() => pool.Get();

        /// <summary>
        /// Вернуть в пул
        /// </summary>
        /// <param name="item"></param>
        public virtual void Release(GameObject item) => pool.Release(item);

        public virtual void Dispose() => pool.Dispose();

        /// <summary>
        /// Очистка пула
        /// </summary>
        public virtual void Clear() => pool.Clear();
    }
}