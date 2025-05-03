using System;
using Cysharp.Threading.Tasks;
using Gameplay.Player;
using Infrastructure;
using Infrastructure.States;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Zenject;

namespace Gameplay.PlayerInfo
{
    [RequireComponent(typeof(AudioSource))]
    public class SwapStage : MonoBehaviour
    {
        [SerializeField] private RectTransform mirror;
        [SerializeField] private RectTransform butHunt;
        [SerializeField] private Image itemTransform;
        [SerializeField] private TextMeshProUGUI textTransform;
        [SerializeField] private TextMeshProUGUI textSkill;
        [SerializeField] private AudioMixerGroup huntVolume;
        [SerializeField] private float notFocusedAlfa = 0.5f;
        [SerializeField] private float focusedAlfa = 1.0f;

        [SerializeField] private SwapStageData[] stages;

        private AudioSource _huntAudioSource;
        private GameStateMachine _stateMachine;
        private PlayerService _playerService;
        private Evolve _currentEvolve;

        [Inject]
        public void Construct(PlayerService playerService, GameStateMachine stateMachine)
        {
            _playerService = playerService;
            _stateMachine = stateMachine;
            _huntAudioSource = GetComponent<AudioSource>() 
                               ?? gameObject.AddComponent<AudioSource>();
        }
        
        public void Start()
        {
            _huntAudioSource.playOnAwake = false;
            _huntAudioSource.outputAudioMixerGroup = huntVolume;
            _currentEvolve = _playerService.CurrentEvolve.Evolve;
            Swap();
        }

        private void Swap()
        {
            // ������� ���������� �������� ������� �� ������
            var anchored = mirror.anchoredPosition;

            foreach (var stage in stages)
            {
                var color = stage.image.color;
                color.a = notFocusedAlfa;
                stage.image.color = color;
                
                if (stage.evolve != _currentEvolve) continue;
                
                anchored.x = -635;
                mirror.anchoredPosition = anchored;
                anchored.y = 50;
                butHunt.anchoredPosition = anchored;

                itemTransform.sprite = stage.spriteItem;
                textTransform.text = stage.questText;
                textSkill.text = stage.skillText;
                
                color.a = focusedAlfa;
                stage.image.color = color;

                _huntAudioSource.clip = stage.huntSound;
            }
        }

        public async void OnHuntButtonClicked()
        {
            _huntAudioSource.Play();
            // Расскоментируй эту строчку если нужен переход по окончанию звука
            //await UniTask.WaitUntil(() => !_huntAudioSource.isPlaying);
            
            // А это переход через 3 секунды (3000 миллисекунд)
            await UniTask.Delay(2500);
            await _stateMachine.Enter<VillageState>();
        }
    }

    [Serializable]
    public class SwapStageData
    {
        public Evolve evolve;
        public Image image;
        public Sprite spriteItem;
        public AudioClip huntSound;
        [TextArea(2,4)]
        public string questText;
        [TextArea(2,4)]
        public string skillText;
    }
}
