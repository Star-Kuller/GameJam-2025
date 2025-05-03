using Gameplay.Village;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers.Village
{
    public class VillageInstaller : MonoInstaller
    {
        [SerializeField] private HouseManager houseManager;
        public override void InstallBindings()
        {
            Container.Bind<EnemyGenerator>().AsSingle();
            Container.Bind<HouseManager>().FromInstance(houseManager).AsSingle();
        }
    }
}