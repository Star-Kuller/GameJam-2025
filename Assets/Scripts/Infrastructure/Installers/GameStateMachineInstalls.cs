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
            Container.Bind<BootstrapState>().AsSingle();
            Container.Bind<VillageState>().AsSingle();
            Container.Bind<InformState>().AsSingle();
            Container.Bind<DeadState>().AsSingle();
            Container.Bind<MenuState>().AsSingle();
            Container.Bind<WinEndingState>().AsSingle();
            Container.Bind<HpEndingState>().AsSingle();
            Container.Bind<HeadEndingState>().AsSingle();
        }
    }
}