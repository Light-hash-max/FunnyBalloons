namespace FunnyBaloons.Interactable
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Объект взаимодейтсвия
    /// </summary>
    public interface IInteractable
    {
        /// <summary>
        /// Произошло взаимодействие
        /// </summary>
        public event Action OnInteract;
    }
}