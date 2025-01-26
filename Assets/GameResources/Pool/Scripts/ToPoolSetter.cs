namespace FunnyBaloons.Pool
{
    using FunnyBaloons.Conditions;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Возвращает сам себя в пул
    /// </summary>
    public class ToPoolSetter : MonoBehaviour
    {
        [SerializeField]
        protected List<AbstractCondition> conditions = new List<AbstractCondition>();

        protected ObjectPoolService poolService = default;

        /// <summary>
        /// Передать сервер для пула
        /// </summary>
        public virtual void Initialize(ObjectPoolService service) => poolService = service;

        protected virtual void ReturnToPool() => poolService.Release(gameObject);

        protected virtual void OnEnable() => conditions.ForEach(x => x.OnComplete += ReturnToPool);

        protected virtual void OnDisable() => conditions.ForEach(x => x.OnComplete -= ReturnToPool);
    }
}