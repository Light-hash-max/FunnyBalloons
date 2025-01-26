namespace FunnyBaloons.Points
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Очки
    /// </summary>
    public class CollectablePoints
    {
        /// <summary>
        /// Изменилось значение
        /// </summary>
        public event Action OnValueChanged = delegate { };

        /// <summary>
        /// Количество очков
        /// </summary>
        public int Count
        {
            get => count;

            set
            {
                count = value;
                OnValueChanged();
            }
        }

        protected int count = 0;
    }
}