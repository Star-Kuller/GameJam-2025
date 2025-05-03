using Gameplay;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class MusicInstaller : MonoInstaller
    {
        [SerializeField] private MusicManager musicManagerPrefab;

        public override void InstallBindings()
        {
            Container
                .Bind<MusicManager>()
                .FromComponentInNewPrefab(musicManagerPrefab)
                .AsSingle()
                .NonLazy();
        }
    }
}
