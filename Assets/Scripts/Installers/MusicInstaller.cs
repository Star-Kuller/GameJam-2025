using System.ComponentModel;
using UnityEngine;
using Zenject;

public class MusicInstaller : MonoInstaller
{
    [SerializeField] private MusicManager _musicManagerPrefab;

    public override void InstallBindings()
    {
        // 1) ������ ��������� MusicManager �� �������
        var musicManager = Container
            .InstantiatePrefabForComponent<MusicManager>(
                _musicManagerPrefab,
                Vector3.zero, Quaternion.identity, null
            );

        // 2) ������� Unity: �� ��������� ����� �������
        Object.DontDestroyOnLoad(musicManager.gameObject);

        // 3) ������������ MusicManager � ���������� Zenject ��� ��������
        Container
            .Bind<MusicManager>()
            .FromInstance(musicManager)
            .AsSingle()
            .NonLazy();
    }
}
