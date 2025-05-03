using UnityEngine;
using Zenject;

public class EndingsSceneInstaller : MonoInstaller
{
    [SerializeField] EndingsManager _endingsManager;

    public override void InstallBindings()
    {

        Container.Bind<EndingsManager>()
                 .FromInstance(_endingsManager)
                 .AsSingle()
                 .NonLazy();


    }
}
