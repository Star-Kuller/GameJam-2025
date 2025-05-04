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
        [SerializeField] private bool isActive;
        
        [SerializeField] private Sprite activeView;
        [SerializeField] private Sprite deactivateView;

        private Image _image;
        private HouseMenu _houseMenu;
        private RectTransform _rectTransform;
        private RectTransform _houseMenuRectTransform;
        
        public EnemyType Villager
        {
            get => villager;
            set => villager = value;
        }

        public bool IsActive
        {
            get => isActive;
            set
            {
                isActive = value;
                if(_image != null) 
                    _image.sprite = isActive ? activeView : deactivateView;
            }
        }

        public IReadOnlyCollection<Evolve> AvailableFor => availableFor;
        public bool IsHeadman => isHeadman;
        
        public void Initialize(bool active, HouseMenu houseMenu)
        {
            _image = GetComponent<Image>()
                     ?? gameObject.AddComponent<Image>();
            IsActive = active;
            _houseMenu = houseMenu;
            _houseMenuRectTransform = _houseMenu.GetComponent<RectTransform>();
            _rectTransform = GetComponent<RectTransform>();
        }

        public void OnHouseClick()
        {
            if (!isActive) return;
            _houseMenuRectTransform.position = _rectTransform.position;
            _houseMenu.House = this;
            _houseMenu.InitSkill();
            _houseMenu.gameObject.SetActive(true);
        }
    }
}