using Cysharp.Threading.Tasks;
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

        VideoPlayer _current;

        [Inject]
        public void Construct() {  }

        public async UniTask PlayWin()
        {
            Debug.Log("ПлейВин ");
            await Play(winPlayer);
        }

        public async UniTask PlayHP()
        {
            await Play(loseHpPlayer);
        }

        public async UniTask PlayHead()
        {
            await Play(loseHeadPlayer);
        }

        private async UniTask Play(VideoPlayer vp)
        {
            Debug.Log("Старт видео " + vp);
            _current = vp;
            _current.gameObject.SetActive(true);
            _current.Play();
            await UniTask.WaitUntil(() => !_current.isPlaying);
        }
    }
}
