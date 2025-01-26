namespace FunnyBaloons.BaseView
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Переключает объекты
    /// </summary>
    public class BaseObjectsSwitcher : MonoBehaviour
    {
        [SerializeField]
        protected List<GameObject> activated = new List<GameObject>();
        [SerializeField]
        protected List<GameObject> deactivated = new List<GameObject>();

        /// <summary>
        /// Перключить объекты
        /// </summary>
        /// <param name="isActivate"></param>
        public virtual void Switch(bool isActivate)
        {
            activated.ForEach(x => x.SetActive(isActivate));
            deactivated.ForEach(x => x.SetActive(!isActivate));
        }

        protected virtual void Switch() => Switch(true);
    }
}