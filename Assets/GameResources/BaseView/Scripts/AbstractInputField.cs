namespace FunnyBaloons.BaseView
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Абстрактный InputField
    /// </summary>
    [RequireComponent(typeof(InputField))]
    public abstract class AbstractInputField : MonoBehaviour
    {
        protected InputField inputField = default;

        protected virtual void Awake()
        {
            inputField = GetComponent<InputField>();
            inputField.onValueChanged.AddListener(OnValueChanged);
        }

        /// <summary>
        /// События при изменении значения inputField
        /// </summary>
        public abstract void OnValueChanged(string inputValue);

        protected virtual void OnDestroy() =>
            inputField.onValueChanged.RemoveListener(OnValueChanged);
    }
}