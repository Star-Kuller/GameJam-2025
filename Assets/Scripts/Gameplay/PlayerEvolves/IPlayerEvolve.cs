namespace Gameplay.PlayerEvolves
{
    public interface IPlayerEvolve
    {
        PlayerEvolve Evolve { get; }
        int MaxHealth { get; }
        int MaxAttention { get; }
        (int attention, int damage) HomeVisit(EnemyType type);
        IPlayerSkill Skill { get; }
    }
}