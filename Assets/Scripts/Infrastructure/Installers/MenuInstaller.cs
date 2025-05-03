using Zenject;
using UnityEngine;

public class MenuInstaller : MonoInstaller
{
    [SerializeField] private StartButtonHandler _startButtonHandler;

    public override void InstallBindings()
    {
        Container.Inject(_startButtonHandler);
    }
}
