using System;
using Cysharp.Threading.Tasks;
using Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure.States
{
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
            var container = SceneManager.GetActiveScene().GetSceneContainer();
            var endingsManager = container.Resolve<EndingsManager>();
            if (endingsManager == null)
                throw new Exception("EndingsManager not found in EndingsScene!");

            await endingsManager.PlayHead();

            await _gameStateMachine.Enter<BootstrapState>();
        }
    }
}
