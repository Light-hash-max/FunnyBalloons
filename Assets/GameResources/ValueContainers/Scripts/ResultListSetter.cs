namespace FunnyBaloons.ValueContainers
{
    using FunnyBaloons.Points;
    using System.Linq;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Выставляет результаты в список результатов
    /// </summary>
    public class ResultListSetter : MonoBehaviour
    {
        [SerializeField]
        protected ResultsListContainer resultsListContainer = default;
        [SerializeField]
        protected StringValueContainer playerName = default;
        [SerializeField, Min(0)]
        protected int maxCount = 3;

        protected ResultsList resultsList = default;
        protected ResultPair resultPair = default;
        protected CollectablePoints collectablePoints = default;

        [Inject]
        protected virtual void Construct(CollectablePoints points) => collectablePoints = points;

        /// <summary>
        /// Обновить список результатов
        /// </summary>
        public virtual void UpdateData()
        {
            resultPair = new ResultPair(playerName.Data, collectablePoints.Count);
            resultsList = new ResultsList(resultsListContainer.Data.ResultPairs);

            SetData();
            resultsList.SetResults(resultsList.ResultPairs.OrderByDescending(x => x.PointsCount).ToList());

            if (resultsList.ResultPairs.Count > maxCount)
            {
                resultsList.SetResults(resultsList.ResultPairs.GetRange(0, maxCount));
            }

            resultsListContainer.Data = resultsList;
        }

        protected virtual void SetData()
        {
            foreach (ResultPair pair in resultsList.ResultPairs)
            {
                if (pair.NamePlayer == resultPair.NamePlayer)
                {
                    if (resultPair.PointsCount > pair.PointsCount)
                    {
                        pair.SetPoints(resultPair.PointsCount);
                    }

                    return;
                }
            }

            resultsList.ResultPairs.Add(resultPair);
        }
    }
}