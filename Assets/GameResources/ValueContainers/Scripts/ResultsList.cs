namespace FunnyBaloons.ValueContainers
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Список результатов
    /// </summary>
    [Serializable]
    public class ResultsList 
    {
        /// <summary>
        /// Список
        /// </summary>
        public List<ResultPair> ResultPairs => resultPairs;

        [SerializeField]
        protected List<ResultPair> resultPairs = new List<ResultPair>();

        public ResultsList(List<ResultPair> pairs) => resultPairs = pairs;

        /// <summary>
        /// Записать результаты
        /// </summary>
        /// <param name="pairs"></param>
        public virtual void SetResults(List<ResultPair> pairs) => resultPairs = pairs;
    }
}