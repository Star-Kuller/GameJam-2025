using Infrastructure.States;
using Zenject;

namespace Infrastructure.Installers
{
    public class GameStateMachineInstaller : MonoInstaller
    {
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            Container.Bind<StateFactory>().AsSingle().NonLazy();
            
            Container.Bind<GameStateMachine>()
                .FromNewComponentOnNewGameObject()
                .WithGameObjectName("GameStateMachine")
                .AsSingle()
                .NonLazy();
            
            //Тут нужно регистрировать состояния игры
            Container.Bind<BootstrapState>().AsSingle().NonLazy();
            Container.Bind<TestState>().AsSingle().NonLazy();
            Container.Bind<VillageState>().AsSingle().NonLazy();
        }
    }
}