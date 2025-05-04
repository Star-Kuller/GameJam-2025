using Cysharp.Threading.Tasks;
using Gameplay;
using Gameplay.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            _playerService.Reset();
            _playerService.ChangeEvolve(Evolve.WhiteHag);
#if UNITY_EDITOR
            var currentScene = SceneManager.GetActiveScene();
            switch (currentScene.name)
            {
                case "Village":
                    await _stateMachine.Enter<VillageState>();
                    return;
                case "PlayerInfo":
                    await _stateMachine.Enter<InformState>();
                    return;
                case "Menu":
                    await _stateMachine.Enter<MenuState>();
                    return;
                //case "End":
                    //await _stateMachine.Enter<WinEndingState>();
                    //return;
            }
#endif
            await _stateMachine.Enter<MenuState>();
        }
    }
}