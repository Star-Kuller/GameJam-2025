using System.Linq;
using Cysharp.Threading.Tasks;
using Gameplay.Player;
using TMPro;
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
        [SerializeField] private HeadmanDialogues headmanDialogues;
        
        [SerializeField] private Image portrait;
        [SerializeField] private TMP_Text text;
        [SerializeField] private TMP_Text result;
        [SerializeField] private AudioSource audio;
        private PlayerService _playerService;
        
        public void OnValidate()
        {
            audio = GetComponent<AudioSource>();
        }

        public async UniTask SayEnemy(Evolve evolve, EnemyType enemyType)
        {
            var currentDialogues = dialogues
                .First(x => x.Evolve == evolve)
                .Dialogues
                .First(x => x.EnemyType == enemyType);

            await Say(currentDialogues);
        }
        
        public async UniTask SayHeadman()
        {
            await Say(headmanDialogues);
        }

        private async UniTask Say(IDialogues currentDialogues)
        {
            var dialogue = currentDialogues.Dialogues[Random.Range(0, currentDialogues.Dialogues.Count - 1)];
            portrait.sprite = currentDialogues.Portrait;
            text.text = dialogue.Text;
            result.text = currentDialogues.ResultText;
            audio.clip = dialogue.Voice;
            audio.Play();
            await UniTask.WaitUntil(() => KeyWasPressed);
            audio.Stop();
            gameObject.SetActive(false);
        }

        private static bool KeyWasPressed => Keyboard.current.spaceKey.wasPressedThisFrame ||
                                             Mouse.current.leftButton.wasPressedThisFrame;
    }
}