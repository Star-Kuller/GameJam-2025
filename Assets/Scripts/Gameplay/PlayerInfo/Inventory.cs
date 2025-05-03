using Gameplay.Player;
using UnityEngine;
using Zenject;

namespace Gameplay.PlayerInfo
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private Transform inventoryPosition;
        [SerializeField] private GameObject spoon;
        [SerializeField] private GameObject chicken;
        [SerializeField] private GameObject man;

        private PlayerService _playerService;
        private Evolve _currentEvolve;
        private int _items;

        [Inject]
        public void Construct(PlayerService playerService)
        {
            _playerService = playerService;
        }
        
        public void Start()
        {
            _currentEvolve = _playerService.CurrentEvolve.Evolve;
            _items = _playerService.Items;
            AddItems();
        }

        private void AddItems()
        {
            foreach (Transform child in inventoryPosition)
            {
                Destroy(child.gameObject);
            }

            var prefabToSpawn = _currentEvolve switch
            {
                Evolve.Igosha => spoon,
                Evolve.Kikimora => chicken,
                Evolve.WhiteHag => man,
                _ => null
            };

            for (var i = 0; i < _items; i++)
            {
                Instantiate(prefabToSpawn, inventoryPosition);
            }
        }
    }
}
