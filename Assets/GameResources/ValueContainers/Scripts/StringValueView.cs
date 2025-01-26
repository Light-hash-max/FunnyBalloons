namespace FunnyBaloons.ValueContainers
{
    using FunnyBaloons.BaseView;
    using UnityEngine;

    /// <summary>
    /// Отображение стрингового значения
    /// </summary>
    public class StringValueView : AbstractTextView
    {
        [SerializeField]
        protected StringValueContainer nameContainer = default;

        protected virtual void OnEnable()
        {
            nameContainer.OnValueChanged += UpdateView;
            UpdateView();
        }

        protected virtual void OnDisable() => nameContainer.OnValueChanged -= UpdateView;

        protected virtual void UpdateView() => text.text = nameContainer.Data;
    }
}