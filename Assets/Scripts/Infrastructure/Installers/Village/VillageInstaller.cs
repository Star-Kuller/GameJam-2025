using Gameplay.Village;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers.Village
{
    public class VillageInstaller : MonoInstaller
    {
        [SerializeField] private HouseManager houseManager;
        [SerializeField] private HouseMenu houseMenu;
        [SerializeField] private DialogueView dialogueView;
        [SerializeField] private VisitCounter visitCounter;
        public override void InstallBindings()
        {
            Container.Bind<EnemyGenerator>().AsSingle();
            Container.Bind<HouseManager>().FromInstance(houseManager).AsSingle();
            Container.Bind<HouseMenu>().FromInstance(houseMenu).AsSingle();
            Container.Bind<DialogueView>().FromInstance(dialogueView).AsSingle();
            Container.Bind<VisitCounter>().FromInstance(visitCounter).AsSingle();
        }
    }
}