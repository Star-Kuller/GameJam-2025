using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public abstract class PlayerSkillBase : ScriptableObject
    {
        [SerializeField] private string skillName;
        [SerializeField] private string description;
        [SerializeField] private int usageLimit;
        [SerializeField] private Image image;
        public abstract void UseEffect();
    }
}