namespace FunnyBaloons.ValueContainers
{
    using FunnyBaloons.BaseView;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Ввод и сохранение имени
    /// </summary>
    public class NameInput : AbstractInputField
    {
        [SerializeField]
        protected List<GameObject> emptyFieldObjects = new List<GameObject>();
        [SerializeField]
        protected List<GameObject> fullFieldObjects = new List<GameObject>();
        [SerializeField]
        protected StringValueContainer nameContainer = default;

        protected virtual void OnEnable()
        {
            if (!string.IsNullOrWhiteSpace(nameContainer.Data))
            {
                inputField.text = nameContainer.Data;
            }

            emptyFieldObjects.ForEach(x => x.SetActive(string.IsNullOrWhiteSpace(inputField.text)));
            fullFieldObjects.ForEach(x => x.SetActive(!string.IsNullOrWhiteSpace(inputField.text)));
        }

        public override void OnValueChanged(string inputValue)
        {
            nameContainer.Data = inputValue;
            emptyFieldObjects.ForEach(x => x.SetActive(string.IsNullOrWhiteSpace(inputValue)));
            fullFieldObjects.ForEach(x => x.SetActive(!string.IsNullOrWhiteSpace(inputValue)));
        }
    }
}