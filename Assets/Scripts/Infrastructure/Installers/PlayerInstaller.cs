using Gameplay;
using Zenject;

namespace Infrastructure.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        // ReSharper disable Unity.PerformanceAnalysis
        //Тут регистрируются различные системы связанные с игроком (ХП, управление и прочее)
        public override void InstallBindings()
        {
            Container.Bind<PlayerService>().AsSingle().NonLazy();
        }
    }
}