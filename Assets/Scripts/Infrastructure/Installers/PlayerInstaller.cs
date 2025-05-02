using Gameplay;
using Gameplay.Inventory;
using Gameplay.PlayerEvolves;
using Zenject;

namespace Infrastructure.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        // ReSharper disable Unity.PerformanceAnalysis
        //Тут регистрируются различные системы связанные с игроком (ХП, управление и прочее)
        public override void InstallBindings()
        {
            Container.Bind<InventoryService>().AsSingle().NonLazy();
            Container.Bind<PlayerService>().AsSingle().NonLazy();
            Container.Bind<Igosha>().AsTransient();
        }
    }
}