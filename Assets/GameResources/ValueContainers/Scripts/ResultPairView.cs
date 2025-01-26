namespace FunnyBaloons.ValueContainers
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Отображение вьюшки пары значений - имя игрока и количество очков
    /// </summary>
    public class ResultPairView : MonoBehaviour
    {
        [SerializeField]
        protected Text namePlayerText = default;
        [SerializeField]
        protected Text pointsCountText = default;

        /// <summary>
        /// Обновить вьюшку
        /// </summary>
        /// <param name="namePlayer"></param>
        /// <param name="pointsCount"></param>
        public virtual void UpdateView(string namePlayer, int pointsCount)
        {
            namePlayerText.text = namePlayer;
            pointsCountText.text = pointsCount.ToString();
        }
    }
}