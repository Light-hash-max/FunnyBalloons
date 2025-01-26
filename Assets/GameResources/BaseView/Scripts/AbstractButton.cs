namespace FunnyBaloons.BaseView
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// UI кнопка
    /// </summary>
    [RequireComponent(typeof(Button))]
    public abstract class AbstractButton : MonoBehaviour
    {
        protected Button button = default;

        protected virtual void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnButtonClick);
        }

        /// <summary>
        /// События при клики на кнопку
        /// </summary>
        public abstract void OnButtonClick();

        protected virtual void OnDestroy() =>
            button.onClick.RemoveListener(OnButtonClick);
    }
}