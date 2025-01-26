namespace FunnyBaloons.Pool
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Zenject;
    using Random = UnityEngine.Random;

    /// <summary>
    /// Регулярно спавнит объект
    /// </summary>
    public class RegularSpawner : MonoBehaviour
    {
        /// <summary>
        /// Создан объет
        /// </summary>
        public event Action OnSpawned = delegate { };

        /// <summary>
        /// Созданные объект
        /// </summary>
        public GameObject SpawnedObject { get; protected set; } = default;

        protected float maxTime = 0.7f;
        protected float minTime = 0.1f;

        [SerializeField]
        protected List<GameObject> prefabs = default;
        [SerializeField]
        protected Transform parent = default;

        protected ObjectPoolService poolService = default;
        protected Coroutine spawnCoroutine = default;
        protected ToPoolSetter toPoolSetter = default;

        [Inject]
        protected virtual void Construct(ObjectPoolService service) => poolService = service;

        protected virtual void OnEnable()
        {
            EndCoroutine();
            spawnCoroutine = StartCoroutine(Spawning());
        }

        protected virtual void OnDisable() => EndCoroutine();

        protected virtual void EndCoroutine()
        {
            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
            }

            spawnCoroutine = null;
        }

        protected IEnumerator Spawning()
        {
            while(isActiveAndEnabled)
            {
                yield return new WaitForSeconds(Random.Range(minTime, maxTime));
                Spawn();
            }
        }

        protected virtual void Spawn()
        {
            SpawnedObject = poolService.Spawn(prefabs[Random.Range(0,prefabs.Count)], parent);
            SpawnedObject.transform.localPosition = Vector3.zero;

            if (SpawnedObject.TryGetComponent(out toPoolSetter))
            {
                toPoolSetter.Initialize(poolService);
            }

            OnSpawned();
        }
    }
}