using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.States
{
    //Это просто тестовое состояние
    public class TestState : IExitableState
    {
        private readonly GameStateMachine _stateMachine;

        public TestState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        //Одна сцена может сопровождаться как одним состоянием,
        //так и несколькими
        public async UniTask OnEnter()
        {
            await SceneManager.LoadSceneAsync("TestScene");
            Debug.Log("Test1");
            await UniTask.Delay(3000);
            Debug.Log("Test2");
        }

        public async UniTask OnExit()
        {
            
        }
    }
}