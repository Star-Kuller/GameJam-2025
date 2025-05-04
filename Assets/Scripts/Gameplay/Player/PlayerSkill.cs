using Gameplay.Village;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Player
{
    public abstract class PlayerSkillBase : ScriptableObject
    {
        [SerializeField] private Sprite sprite;
        [SerializeField] private Sprite spriteHighlight;
        [SerializeField] private Sprite spritePressed;
        [SerializeField] private int usageLimit;

        public Sprite Sprite => sprite;
        public Sprite SpriteHighlight => spriteHighlight;
        public Sprite SpritePressed => spritePressed;
        public int UsageLimit => usageLimit;

        public abstract void UseEffect(House house, HouseMenu houseMenu);
    }
}