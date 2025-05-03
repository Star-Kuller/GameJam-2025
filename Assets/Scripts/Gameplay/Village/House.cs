using System;
using System.Collections.Generic;
using Gameplay.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Village
{
    [RequireComponent(typeof(Image))]
    public class House : MonoBehaviour
    {
        [SerializeField] private EnemyType villager;
        [SerializeField] private bool isHeadman;
        [SerializeField] private Evolve[] availableFor;

        [SerializeField] private Sprite activeView;
        [SerializeField] private Sprite deactivateView;

        private Image _image;
        private bool _isActive;
        
        public EnemyType Villager
        {
            get => villager;
            set => villager = value;
        }

        public IReadOnlyCollection<Evolve> AvailableFor => availableFor;
        public bool IsHeadman => isHeadman;
        
        public void Initialize(bool active)
        {
            _image = GetComponent<Image>()
                     ?? gameObject.AddComponent<Image>();
            _isActive = active;
            _image.sprite = _isActive ? activeView : deactivateView;
        }

        public void OnHouseClick()
        {
            
        }
    }
}