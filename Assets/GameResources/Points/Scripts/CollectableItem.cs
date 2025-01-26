namespace FunnyBaloons.Points
{
    using FunnyBaloons.Interactable;
    using System;
    using UnityEngine;

    /// <summary>
    /// Собираемы объект, который приносит очки
    /// </summary>
    [RequireComponent(typeof(IInteractable))]
    public class CollectableItem : MonoBehaviour
    {
        /// <summary>
        /// Собран
        /// </summary>
        public event Action OnCollected = delegate { };

        [SerializeField, Min(0)]
        protected int points = 1;

        protected IInteractable interactable = default;
        protected CollectablePoints collectablePoints = default;

        /// <summary>
        /// Инициализировать сбор очков
        /// </summary>
        public virtual void Init(CollectablePoints _points) => collectablePoints = _points;

        protected virtual void Awake() => interactable = GetComponent<IInteractable>();

        protected virtual void OnEnable() => interactable.OnInteract += Collect;

        protected virtual void OnDisable() => interactable.OnInteract -= Collect;

        protected virtual void Collect()
        {
            collectablePoints.Count += points;
            OnCollected();
        }
    }
}