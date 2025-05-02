using UnityEngine;
using Zenject;
using Gameplay;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform inventoryPosition;
    [SerializeField] private GameObject spoon;
    [SerializeField] private GameObject chicken;
    [SerializeField] private GameObject man;

    private PlayerEvolve currentEvolve;
    private int quantity;

    private PlayerService _playerService;

    [Inject]
    public void Construct(PlayerService playerService)
    {
        _playerService = playerService;
    }

    void Start()
    {
        // �������� ������� ������
        currentEvolve = _playerService.CurrentEvolve;

        // �������� ���������� ���������
        quantity = _playerService.Items;

        AddItem();
    }

    void AddItem()
    {
        // ������� ���������� ��������
        foreach (Transform child in inventoryPosition)
        {
            Destroy(child.gameObject);
        }

        GameObject prefabToSpawn = null;

        // ����������, ����� ������� ���������� � ����������� �� ������
        switch (currentEvolve.Evolve)
        {
            case Evolve.Igosha:
                prefabToSpawn = spoon;
                break;
            case Evolve.Kikimora:
                prefabToSpawn = chicken;
                break;
            case Evolve.WhiteHag:
                prefabToSpawn = man;
                break;
        }

        for (int i = 0; i < quantity; i++)
        {
            Instantiate(prefabToSpawn, inventoryPosition);
        }
    }
}
