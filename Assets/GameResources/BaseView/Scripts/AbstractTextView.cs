namespace FunnyBaloons.BaseView
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Текст UI
    /// </summary>
    [RequireComponent(typeof(Text))]
    public abstract class AbstractTextView : MonoBehaviour
    {
        protected Text text = default;

        protected virtual void Awake() => text = GetComponent<Text>();
    }
}