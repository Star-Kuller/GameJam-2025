using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeadmanInfo : MonoBehaviour
{
    [SerializeField] private Image headmanBar;
    [SerializeField] private TextMeshProUGUI infHead;
    [SerializeField] GameObject death;
    private int maxHead;
    private int curHead;
    private float percentHead;

    void Start()
    {
        death.SetActive(false);
        maxHead = 100;
        // Тут нужно взять значение текущего внимания старосты
        curHead = 66;

        HeadmanVisual();
    }

    void HeadmanVisual()
    {
        if(curHead >= 100)
        {
            percentHead = 1;
            infHead.text = "100";
            Death();
        }
        else
        {
            percentHead = curHead/maxHead;
            infHead.text = curHead.ToString();
        }
        headmanBar.fillAmount = percentHead;
    }

    void Death()
    {
        death.SetActive(true);
    }
}
