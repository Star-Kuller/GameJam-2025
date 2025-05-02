using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Transform inventoryPosition;
    public GameObject spoon;
    public GameObject chicken;
    public GameObject man;
    private int quantity;
    private int stage;

    void Start()
    {
        //Тут нужно взять текущую стадию
        stage = 1;
        //Тут нужно взять текущее количество предметов
        quantity = 3;
        AddItem();
    }

    void AddItem()
    {
        foreach (Transform child in inventoryPosition)
        {
            Destroy(child.gameObject);
        }

        if (stage == 1)
        {
            for (int i = 0; i < quantity; i++)
            {
                GameObject item = Instantiate(spoon, inventoryPosition);
            }
        }
        else if (stage == 2)
        {
            for (int i = 0; i < quantity; i++)
            {
                GameObject item = Instantiate(chicken, inventoryPosition);
            }
        }
        else
        {
            for (int i = 0; i < quantity; i++)
            {
                GameObject item = Instantiate(man, inventoryPosition);
            }
        }
    }
}
