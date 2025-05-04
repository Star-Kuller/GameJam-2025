using UnityEngine;

namespace Gameplay.Village
{
    public class VisitCounter : MonoBehaviour
    {
        [SerializeField] private GameObject toForrestButton;
        [SerializeField] private int visitCount;
        [SerializeField] private int needToReturnVisits;

        public void Increment()
        {
            visitCount++;
            if(visitCount >= needToReturnVisits)
                toForrestButton.SetActive(true);
        }
    }
}