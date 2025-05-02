using UnityEngine.UI;

namespace Gameplay
{
    public interface IPlayerSkill
    {
        string Name { get; }
        string Description { get; }
        Image Image { get; }

        int UsageLimit { get; }
        void UseEffect();
    }
}