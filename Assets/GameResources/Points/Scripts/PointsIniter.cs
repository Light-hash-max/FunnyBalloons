namespace FunnyBaloons.Points
{
    using FunnyBaloons.Pool;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Инициализирует сбор очков в префабах пула
    /// </summary>
    [RequireComponent(typeof(RegularSpawner))]
    public class PointsIniter : MonoBehaviour
    {
        protected RegularSpawner spawner = default;
        protected CollectablePoints collectablePoints = default;
        protected CollectableItem item = default;

        [Inject]
        protected virtual void Construct(CollectablePoints points) => collectablePoints = points;

        protected virtual void Awake() => spawner = GetComponent<RegularSpawner>();

        protected virtual void OnEnable() => spawner.OnSpawned += InitItem;

        protected virtual void OnDisable() => spawner.OnSpawned -= InitItem;

        protected virtual void InitItem()
        {
            if (spawner.SpawnedObject.TryGetComponent(out item))
            {
                item.Init(collectablePoints);
            }
        }
    }
}