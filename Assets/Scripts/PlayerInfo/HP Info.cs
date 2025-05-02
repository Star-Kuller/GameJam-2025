using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Gameplay;
using Zenject;


public class HPInfo : MonoBehaviour
{
    [SerializeField] private Image healtBar;
    [SerializeField] private TextMeshProUGUI infHealth;
    [SerializeField] GameObject death;
    private int maxHP;
    private int currentHP;
    private float percentHP;

    private PlayerService _playerService;


    [Inject]
    public void Construct(PlayerService playerService)
    {
        _playerService = playerService;
    }

    void Start()
    {
        death.SetActive(false);
        int maxHP = _playerService.MaxHealth;
        int currentHP = _playerService.Health;
        HPVisual();
    }

    
    void HPVisual()
    {
        if (currentHP <= 0)
        {
            percentHP = 0;
            infHealth.text = "0";
            Death();
        }
        else 
        { 
            percentHP = currentHP / maxHP;
            infHealth.text = currentHP.ToString();
        }
        healtBar.fillAmount = percentHP;
    }

    void Death()
    {
        death.SetActive (true);
    }
}



