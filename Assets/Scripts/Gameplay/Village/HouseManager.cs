using System.Linq;
using Gameplay.Player;
using UnityEngine;
using Zenject;

namespace Gameplay.Village
{
    public class HouseManager : MonoBehaviour
    {
        [SerializeField] private House[] houses;
        [SerializeField] private EnemyGeneratorProfile generatorProfile;
        private EnemyGenerator _enemyGenerator;
        private PlayerService _playerService;
        

        [Inject]
        public void Constructor(PlayerService playerService, EnemyGenerator enemyGenerator)
        {
            _enemyGenerator = enemyGenerator;
            _playerService = playerService;
        }

        public void InitializeHouses()
        {
            var evolve = _playerService.CurrentEvolve.Evolve;
            var rules = generatorProfile.RulesList.First(x => x.Evolve == evolve);
            var enemies = _enemyGenerator.Generate(rules);
            foreach (var house in houses)
            {
                var active = house.AvailableFor.Contains(evolve);
                
                if (house.IsHeadman)
                {
                    house.Initialize(active && HaveEnoughItems);
                }
                else
                {
                    house.Initialize(active);
                    if (active) 
                        house.Villager = enemies.Pop();
                }
            }
        }

        private bool HaveEnoughItems => _playerService.Items >= _playerService.CurrentEvolve.TargetItemCount;
    }
}