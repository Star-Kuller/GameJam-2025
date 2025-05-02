using UnityEngine;
using Zenject;
using Gameplay;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip igoshaClip;
    [SerializeField] private AudioClip kikimoraClip;
    [SerializeField] private AudioClip whiteHagClip;

    private PlayerService _playerService;

    [Inject]
    public void Construct(PlayerService playerService)
    {
        _playerService = playerService;
        _playerService.OnEvolveChanged += OnEvolveChanged;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource не назначен в MusicManager!");
            return;
        }

        audioSource.loop = true;
        audioSource.playOnAwake = false;

        PlayClipForEvolve(_playerService.CurrentEvolve?.Evolve ?? Evolve.Igosha);
    }

    private void OnEvolveChanged(Evolve newEvolve)
    {
        PlayClipForEvolve(newEvolve);
    }

    private void PlayClipForEvolve(Evolve evolve)
    {
        AudioClip clip = evolve switch
        {
            Evolve.Igosha => igoshaClip,
            Evolve.Kikimora => kikimoraClip,
            Evolve.WhiteHag => whiteHagClip,
            _ => null
        };

        if (clip != null && audioSource.clip != clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    private void OnDestroy()
    {
        if (_playerService != null)
            _playerService.OnEvolveChanged -= OnEvolveChanged;
    }
}
