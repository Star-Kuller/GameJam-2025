using System;
using Cysharp.Threading.Tasks;
using Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure.States
{
    public class WinEndingState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        [Inject]
        public WinEndingState(GameStateMachine gameStateMachine)
        {
       
            _gameStateMachine = gameStateMachine;
        }

        public async UniTask OnEnter()
        {
            Debug.Log("[WinEndingState] OnEnter - ����� ��������� �����");
            await SceneManager.LoadSceneAsync("End");
            Debug.Log("[WinEndingState] ����� End ���������");

            var container = SceneManager.GetActiveScene().GetSceneContainer();
            var endingsManager = container.Resolve<EndingsManager>();
            if (endingsManager == null)
                throw new Exception("EndingsManager not found in EndingsScene!");


            Debug.Log("Win");
            await endingsManager.PlayWin();


            await _gameStateMachine.Enter<MenuState>();
        }
    }
}
