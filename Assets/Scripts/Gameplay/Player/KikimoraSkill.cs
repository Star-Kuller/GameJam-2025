using Gameplay.Village;
using UnityEngine;

namespace Gameplay.Player
{
    [CreateAssetMenu(fileName = "KikimoraSkill", menuName = "Player/KikimoraSkill", order = 0)]
    public class KikimoraSkill : PlayerSkillBase
    {
        [SerializeField] public EnemyType[] villagers;
        
        public override void UseEffect(House house, HouseMenu houseMenu)
        {
            house.Villager = villagers[Random.Range(0, villagers.Length)];
        }
    }
}