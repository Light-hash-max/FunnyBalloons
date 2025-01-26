namespace FunnyBaloons.ValueContainers
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Результат в виде пары значений - имя и количество очков
    /// </summary>
    [Serializable]
    public class ResultPair
    {
        /// <summary>
        /// Имя игрока
        /// </summary>
        public string NamePlayer => namePlayer;

        /// <summary>
        /// Количество очков
        /// </summary>
        public int PointsCount => pointsCount;

        [SerializeField]
        protected string namePlayer = default;
        [SerializeField]
        protected int pointsCount = default;

        public ResultPair(string name, int points)
        {
            namePlayer = name;
            pointsCount = points;
        }

        /// <summary>
        /// Выставить очки
        /// </summary>
        /// <param name="points"></param>
        public virtual void SetPoints(int points) => pointsCount = points;
    }
}