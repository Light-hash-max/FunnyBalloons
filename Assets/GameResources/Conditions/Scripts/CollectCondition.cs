namespace FunnyBaloons.Conditions
{
    using FunnyBaloons.Points;
    using UnityEngine;

    /// <summary>
    /// Возвращает в пул при сборе объекта
    /// </summary>
    [RequireComponent(typeof(CollectableItem))]
    public class CollectCondition : AbstractCondition
    {
        protected CollectableItem collectable = default;

        protected virtual void Awake() => collectable = GetComponent<CollectableItem>();

        protected override void OnEnable()
        {
            base.OnEnable();
            collectable.OnCollected += SetCompete;
        }

        protected virtual void OnDisable() => collectable.OnCollected -= SetCompete;
    }
}