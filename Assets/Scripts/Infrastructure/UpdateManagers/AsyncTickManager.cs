using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Infrastructure.UpdateManagers.Interfaces;
using UnityEngine;

namespace Infrastructure.UpdateManagers
{
    /// <summary>
    /// Обработчик для асинхронных методов Tick
    /// В методах Register можно добавить в список обновления и Unregister позволяет остановить обновления
    /// </summary>
    public class AsyncTickManager : MonoBehaviour
    {
        private readonly List<IAsyncTick> _ticks = new();
        private int _currentIndex;
        private async UniTaskVoid Update()
        {
            for (_currentIndex = _ticks.Count - 1; _currentIndex >= 0; _currentIndex--)
            {
                await _ticks[_currentIndex].Tick();
            }
        }

        public void Register(IAsyncTick tickable) => _ticks.Add(tickable);
        
        public void UnRegister(IAsyncTick tickable) => _ticks.Remove(tickable);
        
        
        private readonly List<IAsyncFixTick> _fixTicks = new();
        private int _currentIndexFix;
        private async UniTaskVoid FixedUpdate()
        {
            for (_currentIndexFix = _fixTicks.Count - 1; _currentIndexFix >= 0; _currentIndexFix--)
            {
                await _fixTicks[_currentIndexFix].FixTick();
            }
        }

        public void Register(IAsyncFixTick tickable) => _fixTicks.Add(tickable);
        
        public void UnRegister(IAsyncFixTick tickable) => _fixTicks.Remove(tickable);
    }
}