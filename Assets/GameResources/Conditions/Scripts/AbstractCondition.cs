namespace FunnyBaloons.Conditions
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Абстрактное условие
    /// </summary>
    public abstract class AbstractCondition : MonoBehaviour
    {
        /// <summary>
        /// Условие совершилось
        /// </summary>
        public event Action OnComplete = delegate { };

        /// <summary>
        /// Совершилось ли условие
        /// </summary>
        public bool IsComplete
        {
            get => _isComplete;

            protected set
            {
                _isComplete = value;

                if (value)
                {
                    OnComplete();
                }
            }
        }

        private bool _isComplete = false;

        protected virtual void OnEnable() => IsComplete = false;

        /// <summary>
        /// Выполнить условие
        /// </summary>
        protected virtual void SetCompete() => IsComplete = true;
    }
}