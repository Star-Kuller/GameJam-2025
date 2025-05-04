using Gameplay.Player;
using Infrastructure;
using Infrastructure.States;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay.Village
{
    public class HouseMenu : MonoBehaviour
    {
        [SerializeField] private Image skillResult;
        [SerializeField] private Button visitButton;
        [SerializeField] private Button skillButton;
        [SerializeField] private Sprite disabledSprite;
        private PlayerService _playerService;
        private DialogueView _dialogue;
        private VisitCounter _visitCounter;
        private GameStateMachine _gameState;
        private HouseManager _houseManager;
        private int _skillUseCounter;
        public House House { get; set; }

        [Inject]
        public void Constructor(PlayerService playerService, DialogueView dialogue,
            VisitCounter visitCounter, GameStateMachine gameStateMachine, HouseManager houseManager)
        {
            _playerService = playerService;
            _dialogue = dialogue;
            _visitCounter = visitCounter;
            _gameState = gameStateMachine;
            _houseManager = houseManager;
            visitButton.onClick.AddListener(OnVisitClick);
            skillButton.onClick.AddListener(OnSkillClick);
        }
        
        public void OnLeaveClick()
        {
            House.IsActive = false;
            _visitCounter.Increment();
            gameObject.SetActive(false);
        }
        
        public async void OnVisitClick()
        {
            var evolve = _playerService.CurrentEvolve.Evolve;
            House.IsActive = false;
            _dialogue.gameObject.SetActive(true);
            if (House.IsHeadman)
            {
                await _gameState.Enter<WinEndingState>();
            }
            else
            {
                await _dialogue.SayEnemy(evolve, House.Villager);
            }
            if(gameObject.IsDestroyed()) return;
            gameObject.SetActive(false);
            _visitCounter.Increment();
            
            if (evolve == Evolve.WhiteHag && _playerService.Items >= _playerService.CurrentEvolve.TargetItemCount)
                _houseManager.SetActiveOnlyHeadman();
            
            await _playerService.VisitHome(House.Villager);
        }
        
        public void OnSkillClick()
        {
            _skillUseCounter++;
            var skill = _playerService.CurrentEvolve.Skill;
            skillButton.interactable = false;
            skillButton.image.sprite = skill.SpritePressed;
            skill.UseEffect(House, this);
        }

        public void ShowSkillResult(Sprite sprite)
        {
            skillResult.sprite = sprite;
            skillResult.gameObject.SetActive(true);
        }
        
        public void InitSkill()
        {
            var skill = _playerService.CurrentEvolve.Skill;
            skillResult.gameObject.SetActive(false);
            if (skill != null && _skillUseCounter < skill.UsageLimit)
            {
                skillButton.image.sprite = skill.Sprite;
                skillButton.spriteState = new SpriteState
                {
                    highlightedSprite = skill.SpriteHighlight,
                    pressedSprite = skill.SpritePressed
                };
                skillButton.interactable = true;
            }
            else
            {
                skillButton.image.sprite = skill == null ? disabledSprite : skill.SpritePressed;
                skillButton.interactable = false;
            }
                
        }
    }
}
