using System;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "Evolve", menuName = "Player/Evolve", order = 0)]
    public class PlayerEvolve : ScriptableObject
    {
        [SerializeField] private Evolve evolve;
        [SerializeField] private int maxHealth;
        [SerializeField] private int maxAttention;
        [SerializeField] private int targetItemCount;
        [SerializeField] private PlayerSkillBase skill;
        [SerializeField] private EnemyEffect[] enemyEffects = 
        {
            new() { type = EnemyType.Child },
            new() { type = EnemyType.Man },
            new() { type = EnemyType.Woman },
            new() { type = EnemyType.Grandpa },
            new() { type = EnemyType.Grandma }
        };
        
        public Evolve Evolve => evolve;
        public int MaxHealth => maxHealth;
        public int MaxAttention => maxAttention;
        public int TargetItemCount => targetItemCount;
        
        public EnemyEffect GetEnemyEffect(EnemyType type)
        {
            foreach (var effect in enemyEffects)
            {
                if (effect.type == type)
                    return effect;
            }
            throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
    
    [Serializable]
    public class EnemyEffect
    {
        public EnemyType type;
        public int items;
        public int attention;
        public int damage;
    }
}