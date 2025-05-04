//using Gameplay.Menu;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class MenuInstaller : MonoInstaller
    {
        [SerializeField] private StartButtonHandler startButtonHandler;

        public override void InstallBindings()
        {
            Container.Inject(startButtonHandler);
        }
    }
}
