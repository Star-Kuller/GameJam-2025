using Gameplay;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class EndingsSceneInstaller : MonoInstaller
    {
        [SerializeField] EndingsManager endingsManager;

        public override void InstallBindings()
        {

            Container.Bind<EndingsManager>()
                .FromInstance(endingsManager)
                .AsSingle()
                .NonLazy();


        }
    }
}
