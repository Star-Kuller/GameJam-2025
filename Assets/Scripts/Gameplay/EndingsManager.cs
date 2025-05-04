using Cysharp.Threading.Tasks;
using Infrastructure;
using Infrastructure.States;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Video;
using Zenject;

namespace Gameplay
{
    public class EndingsManager : MonoBehaviour
    {
        [SerializeField] VideoPlayer winPlayer;
        [SerializeField] VideoPlayer loseHpPlayer;
        [SerializeField] VideoPlayer loseHeadPlayer;
        private GameStateMachine _stateMachine;
        VideoPlayer _current;

        [Inject]
        public void Construct(GameStateMachine stateMachine) { _stateMachine = stateMachine; }

        public async UniTask PlayWin()
        {//49
            Debug.Log("ПлейВин ");
            await Play(winPlayer, 49000);
        }

        public async UniTask PlayHp()
        { //13
            await Play(loseHpPlayer,13000);
        }

        public async UniTask PlayHead()
        {//27
            await Play(loseHeadPlayer,27000);
        }

        private async UniTask Play(VideoPlayer vp, int timevideo)
        {
            Debug.Log("Старт видео " + vp);
            _current = vp;
            _current.gameObject.SetActive(true);
            _current.Play();

            await UniTask.Delay(timevideo);
            //await UniTask.WaitUntil(() => !_current.isPlaying);
            await _stateMachine.Enter<MenuState>();
        }
    }
}


