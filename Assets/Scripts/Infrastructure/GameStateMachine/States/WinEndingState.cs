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

public class WinEndingState : IState
{
    
    readonly GameStateMachine _gameStateMachine;

    [Inject]
    public WinEndingState(GameStateMachine gameStateMachine)
    {
       
        _gameStateMachine = gameStateMachine;
    }

    public async UniTask OnEnter()
    {
        Debug.Log("[WinEndingState] OnEnter - перед загрузкой сцены");
        await SceneManager.LoadSceneAsync("End");
        Debug.Log("[WinEndingState] Сцена End загружена");

        var endingsManager = UnityEngine.Object.FindObjectOfType<EndingsManager>();
        if (endingsManager == null)
            throw new Exception("EndingsManager not found in EndingsScene!");


        Debug.Log("Win");
        endingsManager.PlayWin();
        Debug.Log("Начало ожидания");
        //Указать нужное время
        await UniTask.Delay(50000);


        await _gameStateMachine.Enter<MenuState>();
    }

    public UniTask OnExit() => UniTask.CompletedTask;
}
