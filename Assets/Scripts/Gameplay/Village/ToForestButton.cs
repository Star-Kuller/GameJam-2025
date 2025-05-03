using Infrastructure;
using Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Gameplay.Village
{
    public class ToForestButton : MonoBehaviour
    {
        private GameStateMachine _stateMachine;
        
        [Inject]
        public void Constructor(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public async void OnClick()
        {
            await _stateMachine.Enter<InformState>();
        }
    }
}