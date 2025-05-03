using System;
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
    public class InformState : IState
    {
        private readonly PlayerService _playerService;
        private readonly MusicManager _musicManager;

        public InformState(PlayerService playerService, MusicManager musicManager)
        {
            _playerService = playerService;
            _musicManager = musicManager;
        }
        
        public async UniTask OnEnter()
        {
            if (_playerService.Items >= _playerService.CurrentEvolve.TargetItemCount)
                NextEvolve();
            await SceneManager.LoadSceneAsync("PlayerInfo");
            _musicManager.PlayClipForEvolve(_playerService.CurrentEvolve.Evolve);
            var sceneContainer = SceneManager.GetActiveScene().GetSceneContainer();
            var deadScreenManager = sceneContainer.Resolve<DeadScreenManager>();
            if (deadScreenManager != null)
            {
                deadScreenManager.HeadmanDeadScreen.SetActive(false);
                deadScreenManager.HpDeadScreen.SetActive(false);
            }
            else
                Debug.LogWarning("DeadScreenManager не найден!");
        }

        private void NextEvolve()
        {
            switch (_playerService.CurrentEvolve.Evolve)
            {
                case Evolve.Igosha:
                    _playerService.ChangeEvolve(Evolve.Kikimora);
                    break;
                case Evolve.Kikimora:
                    _playerService.ChangeEvolve(Evolve.WhiteHag);
                    break;
                case Evolve.WhiteHag:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}