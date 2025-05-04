using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Player;
using Random = UnityEngine.Random;

namespace Gameplay.Village
{
    public class EnemyGenerator
    {
        private readonly EnemyType[] _allEnemies = (EnemyType[])Enum.GetValues(typeof(EnemyType));
        private static int Rand(int range) => Random.Range(0, range);

        public Stack<EnemyType> Generate(EnemyRules rules)
        {
            var result = new List<EnemyType>();
            var pool = new List<EnemyType>(_allEnemies);

            foreach (var rule in rules.Rules)
            {
                for (var i = 0; i < rule.Count; i++)
                {
                    var candidates = pool.Where(e => rule.IsMatch(e)).ToList();

                    if (!candidates.Any())
                        throw new InvalidOperationException(
                            "Невозможно удовлетворить правило: нет подходящих элементов.");

                    var selected = candidates[Rand(candidates.Count)];
                    result.Add(selected);
                }
            }

            while (result.Count < rules.TotalCount)
            {
                var remaining =
                    pool.ToList();
                var selected = remaining[Rand(remaining.Count)];
                result.Add(selected);
            }

            Shuffle(result);
            return new Stack<EnemyType>(result);
        }
        
        private static void Shuffle(List<EnemyType> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = Random.Range(0, n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }
    }
}