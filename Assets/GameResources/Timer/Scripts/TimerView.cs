namespace FunnyBaloons.Timer
{
    using FunnyBaloons.BaseView;
    using System;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Отображение значение таймера
    /// </summary>
    public class TimerView : AbstractTextView
    {
        protected CountdownTimer timer = default;

        [Inject]
        protected virtual void Construct(CountdownTimer countdownTimer) => timer = countdownTimer;

        protected virtual void OnEnable()
        {
            timer.OnTick += UpdateView;
            UpdateView();
        }

        protected virtual void OnDisable() => timer.OnTick -= UpdateView;

        protected virtual void UpdateView() => text.text = TimeSpan.FromSeconds(timer.CurrentSeconds).ToString(@"mm\:ss");
    }
}