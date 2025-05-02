using Cysharp.Threading.Tasks;
using Gameplay;
using UnityEngine;

namespace Infrastructure.States
{
    public class DeadState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly PlayerService _playerService;

        public DeadState(GameStateMachine stateMachine, PlayerService playerService)
        {
            _stateMachine = stateMachine;
            _playerService = playerService;
        }
        
        public async UniTask OnEnter()
        {
            if(_playerService.Health <= 0) 
                Debug.Log("Игрок погиб");
            if(_playerService.Attention <= 0)
                Debug.Log("Староста проявил к игроку слишком много внимания");
        }
    }
}