namespace FunnyBaloons.BaseView
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    /// <summary>
    /// Кнопка загрузки сцены
    /// </summary>
    public class ButtonLoadScene : AbstractButton
    {
        [SerializeField]
        protected string sceneName = "Game";

        public override void OnButtonClick() => SceneManager.LoadScene(sceneName);
    }
}