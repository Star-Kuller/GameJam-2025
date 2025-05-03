using Gameplay.PlayerInfo;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers.InfoScene
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private HeadmanInfo headmanInfo;
        [SerializeField] private HealthInfo healthInfo;
        [SerializeField] private Inventory inventory;
        [SerializeField] private SwapStage swapStage;
        [SerializeField] private DeadScreenManager deadScreenManager;
        
        public override void InstallBindings()
        {
            Container.Bind<DeadScreenManager>().FromInstance(deadScreenManager).AsSingle();
            
            Container.Inject(headmanInfo);
            Container.Inject(healthInfo);
            Container.Inject(inventory);
            Container.Inject(swapStage);
        }
    }
}