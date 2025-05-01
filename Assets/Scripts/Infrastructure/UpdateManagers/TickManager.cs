using System;
using System.Collections.Generic;
using Infrastructure.UpdateManagers.Interfaces;
using UnityEngine;

namespace Infrastructure.UpdateManagers
{
    /// <summary>
    /// Обработчик для методов Tick
    /// В методах Register можно добавить в список обновления и Unregister позволяет остановить обновления
    /// </summary>
    public class TickManager : MonoBehaviour
    {
        private readonly List<ITick> _ticks = new();
        private int _currentIndex;
        private void Update()
        {
            for (_currentIndex = _ticks.Count - 1; _currentIndex >= 0; _currentIndex--)
            {
                _ticks[_currentIndex].Tick();
            }
        }
        
        public void Register(ITick tickable) => _ticks.Add(tickable);
        
        public void UnRegister(ITick tickable) => _ticks.Remove(tickable);
        
        private readonly List<IFixTick> _fixTicks = new();
        private int _currentIndexFix;
        private void FixedUpdate()
        {
            for (_currentIndexFix = _fixTicks.Count - 1; _currentIndexFix >= 0; _currentIndexFix--)
            {
                _fixTicks[_currentIndexFix].FixTick();
            }
        }

        public void Register(IFixTick tickable) => _fixTicks.Add(tickable);
        
        public void UnRegister(IFixTick tickable) => _fixTicks.Remove(tickable);
    }
}