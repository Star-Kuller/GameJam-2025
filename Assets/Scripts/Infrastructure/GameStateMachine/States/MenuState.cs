using Cysharp.Threading.Tasks;
using Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.States
{
    public class MenuState : IState
    {
        readonly MusicManager _musicManager;

        public MenuState(MusicManager musicManager)
        {
            _musicManager = musicManager;
        }

        public async UniTask OnEnter()
        {
            await SceneManager.LoadSceneAsync("Menu");
            _musicManager.PlayMenuTheme();
        }
    }
}
