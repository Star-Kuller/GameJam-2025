using Gameplay.Player;
using UnityEngine;

namespace Gameplay.Village
{
    public class House : MonoBehaviour
    {
        [SerializeField] private EnemyType villager;
        
        public EnemyType Villager
        {
            get => villager;
            set => villager = value;
        }

        public void OnHouseClick()
        {
            
        }
    }
}