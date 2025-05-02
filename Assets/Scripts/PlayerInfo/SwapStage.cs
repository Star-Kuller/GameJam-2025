using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Gameplay.PlayerEvolves;
using Zenject;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwapStage : MonoBehaviour
{
    [SerializeField] private Image imageStage1;
    [SerializeField] private Image imageStage2;
    [SerializeField] private Image imageStage3;
    [SerializeField] private RectTransform mirror;
    [SerializeField] private RectTransform butHunt;
    [SerializeField] private Image itemTransform;
    [SerializeField] private TextMeshProUGUI textTransform;
    [SerializeField] private TextMeshProUGUI textSkill;
    [SerializeField] private Sprite spriteSpoon;
    [SerializeField] private Sprite spriteChicken;
    [SerializeField] private Sprite spriteMan;
    [SerializeField] private AudioSource huntAudioSource;
    [SerializeField] private AudioClip huntSoundStage1;
    [SerializeField] private AudioClip huntSoundStage2;
    [SerializeField] private AudioClip huntSoundStage3;

    private PlayerService _playerService;
    private IPlayerEvolve _currentEvolve;
    private int quantityItem;

    [Inject]
    public void Construct(PlayerService playerService)
    {
        _playerService = playerService;
    }

    void Start()
    {
        _currentEvolve = _playerService.CurrentEvolve; // получаем интерфейс
        quantityItem = _playerService.quantityItem();   // 

        Swap();
    }

    void Swap()
    {
        // Сначала определяем смещение зеркала по стадии
        Vector2 anchored = mirror.anchoredPosition;

        switch (_currentEvolve.Evolve)
        {
            case PlayerEvolve.First:
                anchored.x = -635;
                mirror.anchoredPosition = anchored;
                butHunt.anchoredPosition = anchored;

                itemTransform.sprite = spriteSpoon;
                textTransform.text = "Собери 5 ложек для трансформации.";
                textSkill.text = "Ты еще мала и не обладаешь особыми способностями...";

                SetStageAlpha(1f, 0.5f, 0.5f);

                huntAudioSource.clip = huntSoundStage1;
                break;

            case PlayerEvolve.Second:
                anchored.x = 0;
                mirror.anchoredPosition = anchored;
                butHunt.anchoredPosition = anchored;

                itemTransform.sprite = spriteChicken;
                textTransform.text = "Укради 8 куриц для трансформации.";
                textSkill.text = "Теперь ты умеешь отвлекать жителей.";

                SetStageAlpha(0.5f, 1f, 0.5f);

                huntAudioSource.clip = huntSoundStage2;
                break;

            case PlayerEvolve.Third:
                anchored.x = 635;
                mirror.anchoredPosition = anchored;
                butHunt.anchoredPosition = anchored;

                itemTransform.sprite = spriteMan;
                textTransform.text = "Приворожи 11 мужчин для победы.";
                textSkill.text = "Теперь ты чувствуешь кто находится в доме.";

                SetStageAlpha(0.5f, 0.5f, 1f);

                huntAudioSource.clip = huntSoundStage3;
                break;
        }
    }

    void SetStageAlpha(float a1, float a2, float a3)
    {
        Color c1 = imageStage1.color;
        c1.a = a1;
        imageStage1.color = c1;

        Color c2 = imageStage2.color;
        c2.a = a2;
        imageStage2.color = c2;

        Color c3 = imageStage3.color;
        c3.a = a3;
        imageStage3.color = c3;
    }

    public void OnHuntButtonClicked()
    {
        StartCoroutine(HuntWithDelay());
    }

    private IEnumerator HuntWithDelay()
    {
       
        huntAudioSource.Play();
        
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(3); 
    }
}
