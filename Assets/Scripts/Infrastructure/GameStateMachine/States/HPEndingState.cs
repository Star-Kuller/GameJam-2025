using System;
using Cysharp.Threading.Tasks;
using Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure.States
{
    public class HpEndingState : IState
    {
    
        readonly GameStateMachine _gameStateMachine;

        [Inject]
        public HpEndingState(GameStateMachine gameStateMachine)
        {
        
            _gameStateMachine = gameStateMachine;
        }

        public async UniTask OnEnter()
        {
            await SceneManager.LoadSceneAsync("End");

            var container = SceneManager.GetActiveScene().GetSceneContainer();
            var endingsManager = container.Resolve<EndingsManager>();
            if (endingsManager == null)
                throw new Exception("EndingsManager not found in EndingsScene!");

            await endingsManager.PlayHP();


            await _gameStateMachine.Enter<MenuState>();
        }
    }
}
