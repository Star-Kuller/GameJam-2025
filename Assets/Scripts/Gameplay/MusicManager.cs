using System;
using Gameplay.Player;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicManager : MonoBehaviour
    {
        [SerializeField] private AudioClip menuTheme;
        [SerializeField] private AudioClip igoshaTheme;
        [SerializeField] private AudioClip kikimoraTheme;
        [SerializeField] private AudioClip whiteHagTheme;
        
        private AudioSource _audioSource;

        [Inject]
        public void Constructor()
        {
            _audioSource = GetComponent<AudioSource>() 
                           ?? gameObject.AddComponent<AudioSource>();
            _audioSource.loop = true;
            _audioSource.playOnAwake = false;
        }

        public void PlayMenuTheme()
        {
            _audioSource.clip = menuTheme;
            _audioSource.Play();
        }

        public bool IsPlaying => _audioSource.isPlaying;

        public void PlayClipForEvolve(Evolve evolve)
        {
            var clip = evolve switch
            {
                Evolve.Igosha => igoshaTheme,
                Evolve.Kikimora => kikimoraTheme,
                Evolve.WhiteHag => whiteHagTheme,
                _ => throw new ArgumentOutOfRangeException(nameof(evolve), evolve, null)
            };

            if (clip == null || _audioSource.clip == clip) return;
        
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }
}
