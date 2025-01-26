namespace FunnyBaloons.Interactable
{
    using System;
    using UnityEngine;
    using UnityEngine.EventSystems;

    /// <summary>
    /// Класс взаимодействия через PointerDown
    /// </summary>
    public class PointerDownItem : MonoBehaviour, IInteractable, IPointerDownHandler
    {
        public event Action OnInteract = delegate { };

        public void OnPointerDown(PointerEventData eventData) => OnInteract();
    }
}