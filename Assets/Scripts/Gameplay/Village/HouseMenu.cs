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
        [SerializeField] private Button visitButton;
        private PlayerService _playerService;
        private DialogueView _dialogue;
        private VisitCounter _visitCounter;
        private GameStateMachine _gameState;
        private HouseManager _houseManager;
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
            
        }
    }
}
