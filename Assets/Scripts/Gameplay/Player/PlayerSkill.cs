using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Player
{
    public abstract class PlayerSkillBase : ScriptableObject
    {
        [SerializeField] private string skillName;
        [SerializeField] private string description;
        [SerializeField] private int usageLimit;
        public abstract void UseEffect();
    }
}