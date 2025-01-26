namespace FunnyBaloons.Points
{
    using FunnyBaloons.BaseView;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Отображение полученных очков
    /// </summary>
    public class PointsView : AbstractTextView
    {
        protected CollectablePoints collectablePoints = default;

        [Inject]
        protected virtual void Construct(CollectablePoints points) => collectablePoints = points;

        protected virtual void OnEnable()
        {
            collectablePoints.OnValueChanged += UpdateView;
            UpdateView();
        }

        protected virtual void OnDisable() => collectablePoints.OnValueChanged -= UpdateView;

        protected virtual void UpdateView() => text.text = collectablePoints.Count.ToString();
    }
}