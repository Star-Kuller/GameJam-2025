using System;
using Cysharp.Threading.Tasks;
using Gameplay;
using Gameplay.Player;
using Infrastructure;
using Infrastructure.States;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Video;
using Zenject;

public class StartButtonHandler : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private VideoPlayer introPlayer;
    [SerializeField] private RawImage introDisplay;
    private GameStateMachine _stateMachine;
    private MusicManager _musicManager;

    [Inject]
    public void Construct(GameStateMachine stateMachine, MusicManager musicManager)
    {
        _stateMachine = stateMachine;
        _musicManager = musicManager;
    }

    void Start()
    {
        introDisplay.gameObject.SetActive(false);
        introPlayer.playOnAwake = false;
        introPlayer.isLooping = false;
        startButton.onClick.AddListener(OnStartClicked);
    }

    private async void OnStartClicked()
    {
        if (_musicManager.IsPlaying)
            _musicManager.Stop();

        introDisplay.gameObject.SetActive(true);
        introPlayer.Play();

        await UniTask.WaitUntil(() => !introPlayer.isPlaying);

        await _stateMachine.Enter<VillageState>();
    }
}
