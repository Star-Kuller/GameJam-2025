using UnityEngine;
using UnityEngine.Video;
using Zenject;

public class EndingsManager : MonoBehaviour
{
    [SerializeField] VideoPlayer winPlayer;
    [SerializeField] VideoPlayer loseHPPlayer;
    [SerializeField] VideoPlayer loseHeadPlayer;

    VideoPlayer _current;

    [Inject]
    public void Construct() {  }

    public void PlayWin()
    {
        Debug.Log("ПлейВин ");
        Play(winPlayer);
    }

    public void PlayHP()
    {
        Play(loseHPPlayer);
    }

    public void PlayHead()
    {
        Play(loseHeadPlayer);
    }

    void Play(VideoPlayer vp)
    {
        
        //if (_current != null && _current.isPlaying)
           // _current.Stop();
           Debug.Log("Старт видео " + vp);
        _current = vp;
        _current.gameObject.SetActive(true);
        _current.Play();
    }
}
