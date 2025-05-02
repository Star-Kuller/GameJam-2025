using System.ComponentModel;
using UnityEngine;
using Zenject;

public class MusicInstaller : MonoInstaller
{
    [SerializeField] private MusicManager _musicManagerPrefab;

    public override void InstallBindings()
    {
        // 1) Создаём экземпляр MusicManager из префаба
        var musicManager = Container
            .InstantiatePrefabForComponent<MusicManager>(
                _musicManagerPrefab,
                Vector3.zero, Quaternion.identity, null
            );

        // 2) Говорим Unity: не уничтожай между сценами
        Object.DontDestroyOnLoad(musicManager.gameObject);

        // 3) Регистрируем MusicManager в контейнере Zenject как синглтон
        Container
            .Bind<MusicManager>()
            .FromInstance(musicManager)
            .AsSingle()
            .NonLazy();
    }
}
