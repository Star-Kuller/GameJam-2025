using Gameplay.Player;
using Infrastructure;
using Infrastructure.States;
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
        public House House { get; set; }

        [Inject]
        public void Constructor(PlayerService playerService, DialogueView dialogue,
            VisitCounter visitCounter, GameStateMachine gameStateMachine)
        {
            _playerService = playerService;
            _dialogue = dialogue;
            _visitCounter = visitCounter;
            _gameState = gameStateMachine;
            visitButton.onClick.AddListener(OnVisitClick);
        }
        
        public void OnLeaveClick()
        {
            gameObject.SetActive(false);
        }
        
        public async void OnVisitClick()
        {
            var evolve = _playerService.CurrentEvolve.Evolve;
            House.IsActive = false;
            _dialogue.gameObject.SetActive(true);
            if (House.IsHeadman)
            {
                await _dialogue.SayHeadman();
                await _gameState.Enter<WinEndingState>();
            }
            else
            {
                await _dialogue.SayEnemy(evolve, House.Villager);
            }
            gameObject.SetActive(false);
            _visitCounter.Increment();
            await _playerService.VisitHome(House.Villager);
        }
        
        public void OnSkillClick()
        {
            
        }
    }
}
