namespace FunnyBaloons.Pool
{
    using UnityEngine;

    /// <summary>
    /// Спаунит объекты в диапозоне по X
    /// </summary>
    public class XRangeSpawner : RegularSpawner
    {
        protected float offset = 50f;

        protected float xValue = 0f;

        protected override void Spawn()
        {
            base.Spawn();

            xValue = Screen.width / 2f - offset;
            SpawnedObject.transform.localPosition = new Vector3(Random.Range(-xValue, xValue), 0f, 0f);
        }
    }
}