using System.Linq;
using Cysharp.Threading.Tasks;
using Gameplay.Player;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Zenject;

namespace Gameplay.Village
{
    [RequireComponent(typeof(AudioSource))]
    public class DialogueView : MonoBehaviour
    {
        [SerializeField] private GroupDialogues[] dialogues;
        
        [SerializeField] private Image portrait;
        [SerializeField] private TMP_Text text;
        [SerializeField] private TMP_Text result;
        [SerializeField] private AudioSource audioSource;
        private PlayerService _playerService;
        
        public void OnValidate()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public async UniTask SayEnemy(Evolve evolve, EnemyType enemyType)
        {
            var currentDialogues = dialogues
                .First(x => x.Evolve == evolve)
                .Dialogues
                .First(x => x.EnemyType == enemyType);

            await Say(currentDialogues);
        }

        private async UniTask Say(IDialogues currentDialogues)
        {
            var dialogue = currentDialogues.Dialogues[Random.Range(0, currentDialogues.Dialogues.Count)];
            portrait.sprite = currentDialogues.Portrait;
            text.text = dialogue.Text;
            result.text = currentDialogues.ResultText;
            audioSource.clip = dialogue.Voice;
            audioSource.Play();
            await UniTask.WaitUntil(() => KeyWasPressed);
            if(gameObject.IsDestroyed()) return;
            audioSource.Stop();
            gameObject.SetActive(false);
        }

        private static bool KeyWasPressed => Keyboard.current.spaceKey.wasPressedThisFrame ||
                                             Mouse.current.leftButton.wasPressedThisFrame;
    }
}