using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.States
{
    public class VillageState : IState
    {
        public async UniTask OnEnter()
        {
            await SceneManager.LoadSceneAsync("Village");
        }
    }
}