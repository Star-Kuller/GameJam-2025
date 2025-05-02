using Cysharp.Threading.Tasks;
using Gameplay;
using UnityEngine;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly PlayerService _playerService;

        public BootstrapState(GameStateMachine stateMachine, PlayerService playerService)
        {
            _stateMachine = stateMachine;
            _playerService = playerService;
        }
        
        //Это начальное состояние, тут прописываем всё что нужно сделать перед стартом основной игры
        public async UniTask OnEnter()
        {
            Debug.Log("Инициализация игры...");
            _playerService.ChangeEvolve(Evolve.Igosha);
            await _stateMachine.Enter<VillageState>();
        }
    }
}