namespace FunnyBaloons.TweenAnimation
{
    using DG.Tweening;
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    /// <summary>
    /// Твин анимация
    /// </summary>
    public abstract class AbstractTween: MonoBehaviour
    {
        /// <summary>
        /// Закончилась анимация
        /// </summary>
        public event Action OnComplete = delegate { };

        /// <summary>
        /// Твин анимация
        /// </summary>
        public Tween TweenAnimation { get; protected set; } = default;

        [SerializeField]
        protected List<UnityEvent> unityEvents = new List<UnityEvent>();

        protected virtual void CallCompete()
        {
            unityEvents.ForEach(x => x.Invoke());
            OnComplete();
        }

        protected virtual void OnEnable() => StopAnimation();

        protected virtual void OnDisable() => StopAnimation();

        protected virtual void StopAnimation()
        {
            if (TweenAnimation != null)
            {
                TweenAnimation.Kill();
            }
        }
    }
}