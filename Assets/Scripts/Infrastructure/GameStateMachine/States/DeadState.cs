using Cysharp.Threading.Tasks;
using Gameplay;
using Gameplay.Player;
using UnityEngine;

namespace Infrastructure.States
{
    public class DeadState : IState
    {
        private readonly PlayerService _playerService;

        public DeadState(PlayerService playerService)
        {
            _playerService = playerService;
        }
        
        public UniTask OnEnter()
        {
            if(_playerService.Health <= 0) 
                Debug.Log("Игрок погиб");
            if(_playerService.Attention <= 0)
                Debug.Log("Староста проявил к игроку слишком много внимания");
            return UniTask.CompletedTask;
        }
    }
}