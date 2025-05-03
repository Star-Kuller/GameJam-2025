using System;
using Cysharp.Threading.Tasks;
using Gameplay;
using Gameplay.Player;
using Infrastructure;
using Infrastructure.States;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using Zenject;

public class HeadEndingState : IState
{
    
    readonly GameStateMachine _gameStateMachine;

    [Inject]
    public HeadEndingState( GameStateMachine gameStateMachine)
    {
        
        _gameStateMachine = gameStateMachine;
    }

    public async UniTask OnEnter()
    {
        await SceneManager.LoadSceneAsync("End");

        var endingsManager = UnityEngine.Object.FindObjectOfType<EndingsManager>();
        if (endingsManager == null)
            throw new Exception("EndingsManager not found in EndingsScene!");

        endingsManager.PlayHead();

        //������� ������ �����
        await UniTask.Delay(51110);


        await _gameStateMachine.Enter<MenuState>();
    }

    public UniTask OnExit() => UniTask.CompletedTask;
}
