using Infrastructure.UpdateManagers;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class InfrastructureInstaller : MonoInstaller
    {
        // ReSharper disable Unity.PerformanceAnalysis
        //Тут нужно регистрировать состояния игры
        public override void InstallBindings()
        {
            Container.Bind<TickManager>()
                .FromNewComponentOnNewGameObject()
                .WithGameObjectName("TickManager")
                .AsSingle()
                .NonLazy();
            
            Container.Bind<AsyncTickManager>()
                .FromNewComponentOnNewGameObject()
                .WithGameObjectName("AsyncTickManager")
                .AsSingle()
                .NonLazy();
        }
    }
}
