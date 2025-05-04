using System;
using System.Linq;
using Gameplay.Village;
using UnityEngine;

namespace Gameplay.Player
{
    [CreateAssetMenu(fileName = "WhiteHagSkill", menuName = "Player/WhiteHagSkill", order = 0)]
    public class WhiteHagSkill : PlayerSkillBase
    {
        [SerializeField] public EnemyPortrait[] enemyPortraits;
        public override void UseEffect(House house, HouseMenu houseMenu)
        {
            var portrait = enemyPortraits
                .First(x => x.EnemyType == house.Villager);
            houseMenu.ShowSkillResult(portrait.Sprite);
        }
    }

    [Serializable]
    public class EnemyPortrait
    {
        [SerializeField] private EnemyType enemyType;
        [SerializeField] private Sprite sprite;

        public EnemyType EnemyType => enemyType;
        public Sprite Sprite => sprite;
    }
}