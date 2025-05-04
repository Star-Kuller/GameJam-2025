using Cysharp.Threading.Tasks;
using Infrastructure;
using Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Zenject;

namespace Gameplay.Menu
{
    public class StartButtonHandler : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button nextButton;
        [SerializeField] private VideoPlayer introPlayer;
        [SerializeField] private RawImage introDisplay;
        private GameStateMachine _stateMachine;
        private MusicManager _musicManager;

        [Inject]
        public void Construct(GameStateMachine stateMachine, MusicManager musicManager)
        {
            _stateMachine = stateMachine;
            _musicManager = musicManager;
        }

        void Start()
        {
            introDisplay.gameObject.SetActive(false);
            introPlayer.playOnAwake = false;
            introPlayer.isLooping = false;
            startButton.onClick.AddListener(OnStartClicked);
            nextButton.onClick.AddListener(OnNextClicked);
        }

        private async void OnStartClicked()
        {
            if (_musicManager.IsPlaying)
                _musicManager.Stop();

            introDisplay.gameObject.SetActive(true);
            introPlayer.Play();

            //await UniTask.WaitUntil(() => !introPlayer.isPlaying);
            await UniTask.Delay(51000);

            await _stateMachine.Enter<VillageState>();
        }

        private async void OnNextClicked()
        {
        
            await _stateMachine.Enter<VillageState>();
        }
    }
}
