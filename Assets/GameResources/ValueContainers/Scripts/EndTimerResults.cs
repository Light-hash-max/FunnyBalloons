namespace FunnyBaloons.ValueContainers
{
    using FunnyBaloons.Timer;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Выставляет результат при окончании таймера
    /// </summary>
    public class EndTimerResults : MonoBehaviour
    {
        [SerializeField]
        protected ResultListSetter resultListSetter = default;

        protected CountdownTimer timer = default;

        [Inject]
        protected virtual void Construct(CountdownTimer countdownTimer) => timer = countdownTimer;

        protected virtual void OnEnable() => timer.OnTimerComplete += SetResults;

        protected virtual void OnDisable() => timer.OnTimerComplete -= SetResults;

        protected virtual void SetResults() => resultListSetter.UpdateData();
    }
}