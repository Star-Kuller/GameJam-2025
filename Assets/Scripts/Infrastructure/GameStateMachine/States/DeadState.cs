using System.Linq;
using Cysharp.Threading.Tasks;
using Gameplay;
using Gameplay.Player;
using Gameplay.PlayerInfo;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure.States
{
    public class DeadState : IState
    {
        private readonly PlayerService _playerService;

        public DeadState(PlayerService playerService)
        {
            _playerService = playerService;
        }
        
        public async UniTask OnEnter()
        {
            await SceneManager.LoadSceneAsync("PlayerInfo");
            var sceneContainer = SceneManager.GetActiveScene().GetSceneContainer();
            var deadScreenManager = sceneContainer.TryResolve<DeadScreenManager>();
            if (deadScreenManager != null)
            {
                deadScreenManager.HeadmanDeadScreen.SetActive(false);
                deadScreenManager.HpDeadScreen.SetActive(false);
            }
            else
                Debug.LogWarning("DeadScreenManager не найден!");

            if (_playerService.Health <= 0)
            {
                Debug.Log("Игрок погиб");
                deadScreenManager.HpDeadScreen.SetActive(true);
            }

            if (_playerService.Attention <= 0)
            {
                Debug.Log("Староста проявил к игроку слишком много внимания");
                deadScreenManager.HeadmanDeadScreen.SetActive(true);
            }
        }
    }
}