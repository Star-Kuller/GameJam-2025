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

public class HPEndingState : IState
{
    
    readonly GameStateMachine _gameStateMachine;

    [Inject]
    public HPEndingState(GameStateMachine gameStateMachine)
    {
        
        _gameStateMachine = gameStateMachine;
    }

    public async UniTask OnEnter()
    {
        await SceneManager.LoadSceneAsync("End");

        var endingsManager = UnityEngine.Object.FindObjectOfType<EndingsManager>();
        if (endingsManager == null)
            throw new Exception("EndingsManager not found in EndingsScene!");

        endingsManager.PlayHP();

        //”казать нужное врем€
        await UniTask.Delay(51110);


        await _gameStateMachine.Enter<MenuState>();
    }

    public UniTask OnExit() => UniTask.CompletedTask;
}
