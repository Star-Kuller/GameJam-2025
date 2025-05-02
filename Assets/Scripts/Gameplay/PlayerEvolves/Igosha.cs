using System;

namespace Gameplay.PlayerEvolves
{
    public class Igosha : IPlayerEvolve
    {
        public PlayerEvolve Evolve { get; }
        public int MaxHealth { get; }
        public int MaxAttention { get; }
        
        public (int attention, int damage) HomeVisit(EnemyType type)
        {
            switch (type)
            {
                //TODO Добавить получение урона, внимания и предметов
                case EnemyType.Child:
                    return (0,0);
                case EnemyType.Grandpa:
                    return (0,0);
                case EnemyType.Man:
                    return (0,0);
                case EnemyType.Woman:
                    return (0,0);
                case EnemyType.Grandma:
                    return (0,0);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public IPlayerSkill Skill => null;
    }
}