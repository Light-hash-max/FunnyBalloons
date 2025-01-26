namespace FunnyBaloons.ValueContainers
{
    using FunnyBaloons.Pool;
    using System.Collections.Generic;
    using Unity.VisualScripting;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Вьюшка списка результатов
    /// </summary>
    public class ResultsListView : MonoBehaviour
    {
        [SerializeField]
        protected ResultsListContainer resultsListContainer = default;
        [SerializeField]
        protected ResultPairView prefab = default;
        [SerializeField]
        protected Transform parent = default;

        protected List<ResultPairView> resultPairViews = new List<ResultPairView>();
        protected ResultPairView spawnedObject = default;
        protected ObjectPoolService poolService = default;
        protected int currentCount = 0;

        [Inject]
        protected virtual void Construct(ObjectPoolService service) => poolService = service;

        protected virtual void OnEnable()
        {
            resultsListContainer.OnValueChanged += UpdateView;
            UpdateView();
        }

        protected virtual void OnDisable() => resultsListContainer.OnValueChanged -= UpdateView;

        protected virtual void UpdateView()
        {
            resultPairViews.ForEach(x => poolService.Release(x.gameObject));
            currentCount = resultPairViews.Count;

            for (int i = 0; i < resultsListContainer.Data.ResultPairs.Count; i++)
            {
                spawnedObject = poolService.Spawn(prefab.gameObject, parent).GetComponent<ResultPairView>();
                spawnedObject.transform.localScale = Vector3.one;
                spawnedObject.transform.SetSiblingIndex(i);
                spawnedObject.UpdateView(resultsListContainer.Data.ResultPairs[i].NamePlayer, resultsListContainer.Data.ResultPairs[i].PointsCount);
                resultPairViews.Add(spawnedObject);
            }
        }
    }
}