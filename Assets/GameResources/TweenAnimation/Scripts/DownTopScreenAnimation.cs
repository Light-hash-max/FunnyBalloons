namespace FunnyBaloons.TweenAnimation
{
    using DG.Tweening;
    using System;
    using UnityEngine;
    using Random = UnityEngine.Random;

    /// <summary>
    /// Анимация перемещения наверх через твины
    /// </summary>
    public class DownTopScreenAnimation : AbstractTween
    {
        [SerializeField, Min(0f)]
        protected float maxSpeed = 1500f;
        [SerializeField, Min(0f)]
        protected float minSpeed = 1000f;
        [SerializeField, Min(0f)]
        protected float offset = 300f;

        protected float distance = 0f;

        protected virtual void Awake() => distance = Screen.height + offset - transform.position.y;

        protected override void OnEnable()
        {
            base.OnEnable();
            TweenAnimation = transform.DOMoveY(Screen.height + offset, distance/Random.Range(minSpeed, maxSpeed)).SetEase(Ease.Linear).OnComplete(CallCompete);
        }
    }
}