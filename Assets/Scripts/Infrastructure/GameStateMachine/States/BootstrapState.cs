using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        //Это начальное состояние, тут прописываем всё что нужно сделать перед стартом основной игры
        public async UniTask OnEnter()
        {
            Debug.Log("Инициализация игры...");
            await _stateMachine.Enter<TestState>();
        }
    }
}