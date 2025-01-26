namespace FunnyBaloons.Timer
{
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Запускает таймер обратного отсчета на OnEnable
    /// </summary>
    public class EnableTimerStarter : MonoBehaviour
    {
        [SerializeField, Min(0)]
        protected int timerSeconds = 30;

        protected CountdownTimer timer = default;

        [Inject]
        protected virtual void Construct(CountdownTimer countdownTimer) => timer = countdownTimer;

        protected virtual void OnEnable() => timer.StartTimer(timerSeconds);
    }
}