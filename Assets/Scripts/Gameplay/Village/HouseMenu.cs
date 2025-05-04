using Gameplay.Player;
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
        public House House { get; set; }

        [Inject]
        public void Constructor(PlayerService playerService, DialogueView dialogue)
        {
            _playerService = playerService;
            _dialogue = dialogue;
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
            }
            else
            {
                await _dialogue.SayEnemy(evolve, House.Villager);
            }
            gameObject.SetActive(false);
            await _playerService.VisitHome(House.Villager);
        }
        
        public void OnSkillClick()
        {
            
        }
    }
}
