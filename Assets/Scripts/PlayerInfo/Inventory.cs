using UnityEngine;
using Zenject;
using Gameplay.PlayerEvolves;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform inventoryPosition;
    [SerializeField] private GameObject spoon;
    [SerializeField] private GameObject chicken;
    [SerializeField] private GameObject man;

    private IPlayerEvolve currentEvolve;
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
        currentEvolve = _playerService.CurrentEvolve();

        // �������� ���������� ���������
        quantity = _playerService.QuantityItem();

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
            case PlayerEvolve.First:
                prefabToSpawn = spoon;
                break;
            case PlayerEvolve.Second:
                prefabToSpawn = chicken;
                break;
            case PlayerEvolve.Third:
                prefabToSpawn = man;
                break;
        }

        for (int i = 0; i < quantity; i++)
        {
            Instantiate(prefabToSpawn, inventoryPosition);
        }
    }
}
