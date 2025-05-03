using Gameplay.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay.PlayerInfo
{
    public class HeadmanInfo : MonoBehaviour
    {
        [SerializeField] private Image headmanBar;
        [SerializeField] private TextMeshProUGUI infHead;
        private int _maxAttention;
        private int _attention;
        
        private PlayerService _playerService;

        [Inject]
        public void Construct(PlayerService playerService)
        {
            _playerService = playerService;
        }

        public void Start()
        {
            _maxAttention = _playerService.CurrentEvolve.MaxAttention;
            _attention = _playerService.Attention;
            HeadmanVisual();
        }

        private void HeadmanVisual()
        {
            var percentHead = _attention / _maxAttention;
            infHead.text = _attention.ToString();    
            headmanBar.fillAmount = percentHead;
        }
    }
}
