namespace FunnyBaloons.Timer
{
    using FunnyBaloons.BaseView;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Переключает объекты при завершении таймера
    /// </summary>
    public class EndTimerObjectsSwitcher : BaseObjectsSwitcher
    {
        protected CountdownTimer timer = default;

        [Inject]
        protected virtual void Construct(CountdownTimer countdownTimer) => timer = countdownTimer;

        protected virtual void OnEnable() => timer.OnTimerComplete += Switch;

        protected virtual void OnDisable() => timer.OnTimerComplete -= Switch;
    }
}