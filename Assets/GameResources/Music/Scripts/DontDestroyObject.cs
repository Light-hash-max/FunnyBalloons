namespace FunnyBaloons.Music
{
    using UnityEngine;

    /// <summary>
    /// Неуничтожаемый объект
    /// </summary>
    public class DontDestroyObject : MonoBehaviour
    {
        protected static DontDestroyObject instance;

        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}