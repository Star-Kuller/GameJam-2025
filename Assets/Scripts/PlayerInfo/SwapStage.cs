using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private int currentStage;
    private int quantityItem;

    void Start()
    {
        // Тут нужно взять значение текущей стадии
        currentStage = 1;
        // Тут нужно взять значение количества собраных предметов
        quantityItem = 2;
        CheckStage();
    }

    void CheckStage()
    {
        if (currentStage == 1 && quantityItem >= 5)
        {
            currentStage++;
            Swap();
        }
        else if (currentStage == 2 && quantityItem >= 8)
        {
            currentStage++;
            Swap();
        }
        else if(currentStage == 3 && quantityItem >= 11)
        {
            currentStage++;
            Swap();
        }
        else
        {
            Swap();
        }

    }

    void Swap()
    {
        if (currentStage == 1)
        {
            Vector2 anchoredM = mirror.anchoredPosition;
            anchoredM.x = -635;
            mirror.anchoredPosition = anchoredM;

            Vector2 anchoredH = mirror.anchoredPosition;
            anchoredH.x = -635;
            mirror.anchoredPosition = anchoredH;

            itemTransform.sprite = spriteSpoon;
            textTransform.text = "Собери 5 ложек для трансформации.";
            textSkill.text = "Ты еще мала и не обладаешь особыми способностями...";

            Color c1 = imageStage1.color;
            c1.a = 1f;
            imageStage1.color = c1;

            Color c2 = imageStage2.color;
            c2.a = 0.5f;
            imageStage1.color = c2;

            Color c3 = imageStage3.color;
            c3.a = 0.5f;
            imageStage1.color = c3;
        }
        else if (currentStage == 2)
        {
            Vector2 anchoredM = mirror.anchoredPosition;
            anchoredM.x = 0;
            mirror.anchoredPosition = anchoredM;

            Vector2 anchoredH = mirror.anchoredPosition;
            anchoredH.x = 0;
            mirror.anchoredPosition = anchoredH;

            itemTransform.sprite = spriteChicken;
            textTransform.text = "Укради 8 куриц для трансформации.";
            textSkill.text = "Теперь ты умеешь отвлекать жителей.";

            Color c1 = imageStage1.color;
            c1.a = 0.5f;
            imageStage1.color = c1;

            Color c2 = imageStage2.color;
            c2.a = 1f;
            imageStage1.color = c2;

            Color c3 = imageStage3.color;
            c3.a = 0.5f;
            imageStage1.color = c3;
        }
        else
        {
            Vector2 anchoredM = mirror.anchoredPosition;
            anchoredM.x = 635;
            mirror.anchoredPosition = anchoredM;

            Vector2 anchoredH = mirror.anchoredPosition;
            anchoredH.x = 635;
            mirror.anchoredPosition = anchoredH;

            itemTransform.sprite = spriteMan;
            textTransform.text = "Приворожи 11 мужчин для победы.";
            textSkill.text = "Теперь ты чувствуешь кто находится в доме.";

            Color c1 = imageStage1.color;
            c1.a = 0.5f;
            imageStage1.color = c1;

            Color c2 = imageStage2.color;
            c2.a = 0.5f;
            imageStage1.color = c2;

            Color c3 = imageStage3.color;
            c3.a = 1f;
            imageStage1.color = c3;
        }
    }
}
