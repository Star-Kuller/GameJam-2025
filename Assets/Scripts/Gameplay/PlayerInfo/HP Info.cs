using Gameplay.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay.PlayerInfo
{
    public class HealthInfo : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        [SerializeField] private TextMeshProUGUI healthText;
        private float _maxHealth;
        private float _health;

        private PlayerService _playerService;
        
        [Inject]
        public void Construct(PlayerService playerService)
        {
            _playerService = playerService;
        }
        
        public void Start()
        {
            _maxHealth = _playerService.MaxHealth;
            _health = _playerService.Health;
            HpVisual();
        }

        private void HpVisual()
        {
            var percentHp = _health / _maxHealth;
            healthText.text = _health.ToString();
            Debug.Log(percentHp);
            healthBar.fillAmount = percentHp;
        }
    }
}



