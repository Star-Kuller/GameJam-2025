using System;
using System.Collections.Generic;
using Gameplay.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Village
{
    [CreateAssetMenu(fileName = "EnemyDialogues", menuName = "Dialogues/Enemy", order = 0)]
    public class EnemyDialogues : ScriptableObject, IDialogues
    {
        [SerializeField] private EnemyType enemyType;
        [SerializeField] private Dialogue[] dialogues;
        [SerializeField, TextArea(2, 4)] private string resultText;
        [SerializeField] private Sprite portrait;
       
        public Sprite Portrait => portrait;
        public EnemyType EnemyType => enemyType;
        public IReadOnlyList<Dialogue> Dialogues => dialogues;
        public string ResultText => resultText;
    }

    [Serializable]
    public class Dialogue
    {
        [SerializeField, TextArea(2,4)] private string text;
        [SerializeField] private AudioClip voice;

        public AudioClip Voice => voice;
        public string Text => text;
    }
}