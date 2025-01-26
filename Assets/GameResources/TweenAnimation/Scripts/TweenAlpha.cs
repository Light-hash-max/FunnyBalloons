namespace FunnyBaloons.TweenAnimation
{
    using DG.Tweening;
    using UnityEngine;

    /// <summary>
    /// Твин прозрачности
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class TweenAlpha : AbstractTween
    {
        [SerializeField, Range(0f, 1f)]
        protected float endValue = 1f;
        [SerializeField, Min(0f)]
        protected float duration = 1f;
        [SerializeField, Min(0f)]
        protected float delay = 0f;
        [SerializeField]
        protected int loops = 1;
        [SerializeField]
        protected LoopType loopType = default;

        protected CanvasGroup canvasGroup = default;

        protected virtual void Awake() => canvasGroup = GetComponent<CanvasGroup>();

        protected override void OnEnable()
        {
            base.OnEnable();
            canvasGroup.alpha = 1f - endValue;
            TweenAnimation = canvasGroup.DOFade(endValue, duration).SetDelay(delay).SetLoops(loops, loopType).OnComplete(CallCompete);
        }
    }
}