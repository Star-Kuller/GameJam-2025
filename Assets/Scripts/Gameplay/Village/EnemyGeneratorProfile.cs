using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Player;
using UnityEngine;

namespace Gameplay.Village
{
    [CreateAssetMenu(fileName = "EnemyGenerator", menuName = "Player/Profile", order = 0)]
    public class EnemyGeneratorProfile : ScriptableObject
    {
        [SerializeField] private EnemyRules[] rulesList;
        public IReadOnlyCollection<EnemyRules> RulesList => rulesList;
    }

    [Serializable]
    public class EnemyRules
    {
        [SerializeField] private Evolve evolve;
        [SerializeField] private EnemyRule[] enemyRules;

        public int TotalCount => enemyRules.Select(x => x.Count).Sum();
        public Evolve Evolve => evolve;
        public IReadOnlyCollection<EnemyRule> Rules => enemyRules;
    }

    [Serializable]
    public class EnemyRule
    {
        [SerializeField] private EnemyType[] enemyTypes;
        [SerializeField] private int count;

        public int Count => count;

        public bool IsMatch(EnemyType type) => enemyTypes.Contains(type);
    }
}