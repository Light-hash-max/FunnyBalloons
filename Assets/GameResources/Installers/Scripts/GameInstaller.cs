namespace FunnyBaloons.Installers
{
    using FunnyBaloons.Points;
    using FunnyBaloons.Pool;
    using FunnyBaloons.Timer;
    using UnityEditor;
    using UnityEngine;
    using Zenject;

    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ObjectPoolService>().ToSelf().AsSingle();
            Container.Bind<CollectablePoints>().ToSelf().AsSingle();
            Container.Bind<CountdownTimer>().ToSelf().AsSingle();
        }
    }
}