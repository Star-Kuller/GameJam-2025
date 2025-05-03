using UnityEngine;

namespace Gameplay.PlayerInfo
{
    public class DeadScreenManager : MonoBehaviour
    {
        [SerializeField] private GameObject hpDeadScreen;
        [SerializeField] private GameObject headmanDeadScreen;

        public GameObject HpDeadScreen => hpDeadScreen;
        public GameObject HeadmanDeadScreen => headmanDeadScreen;
    }
}