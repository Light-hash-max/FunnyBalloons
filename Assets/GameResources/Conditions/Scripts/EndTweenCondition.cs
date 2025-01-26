namespace FunnyBaloons.Conditions
{
    using FunnyBaloons.TweenAnimation;
    using UnityEngine;

    /// <summary>
    /// Возвращает себя в пул, когда заканчивается твин анимация
    /// </summary>
    [RequireComponent(typeof(AbstractTween))]
    public class EndTweenCondition : AbstractCondition
    {
        protected AbstractTween tweenAnimation = default;

        protected virtual void Awake() => tweenAnimation = GetComponent<AbstractTween>();

        protected override void OnEnable()
        {
            base.OnEnable();
            tweenAnimation.OnComplete += SetCompete;
        }

        protected virtual void OnDisable() => tweenAnimation.OnComplete -= SetCompete;
    }
}