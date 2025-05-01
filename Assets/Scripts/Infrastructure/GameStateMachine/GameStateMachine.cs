using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    /// <summary>
    /// Эта система контролирует то в каком состоянии сейчас игра
    /// </summary>
    public class GameStateMachine : MonoBehaviour
    {
        private Dictionary<Type, IState> _states;
        private StateFactory _stateFactory;
        private IState _currentState;

        [Inject]
        public void Construct(StateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        private async UniTaskVoid Start()
        {
            _states = new Dictionary<Type, IState>
            {
                //Сюда добавляем все состояния игры
                [typeof(BootstrapState)] = _stateFactory.CreateState<BootstrapState>(),
                [typeof(TestState)] = _stateFactory.CreateState<TestState>()
            };
            await Enter<BootstrapState>();
        }

        /// <summary>
        /// Это метод перехода в другое состояние
        /// </summary>
        /// <typeparam name="T">Целевое состояние</typeparam>
        public async UniTask Enter<T>()
        {
            if(_currentState is IExitableState exitableState) 
                await exitableState.OnExit();
            _currentState = _states[typeof(T)];
            await _currentState.OnEnter();
        }
    }
}