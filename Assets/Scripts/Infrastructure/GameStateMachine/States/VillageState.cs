using Cysharp.Threading.Tasks;
using Gameplay;
using Gameplay.Player;
using Gameplay.Village;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.States
{
    public class VillageState : IState
    {
        private readonly PlayerService _playerService;
        private readonly MusicManager _musicManager;
        public VillageState(PlayerService playerService, MusicManager musicManager)
        {
            _playerService = playerService;
            _musicManager = musicManager;
        }
        public async UniTask OnEnter()
        {
            await SceneManager.LoadSceneAsync("Village");
            _musicManager.PlayClipForEvolve(_playerService.CurrentEvolve.Evolve);
            var container = SceneManager.GetActiveScene().GetSceneContainer();
            var houseManager = container.Resolve<HouseManager>();
            houseManager.InitializeHouses();
        }
    }
}