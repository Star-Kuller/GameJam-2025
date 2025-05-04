using System;
using System.Collections.Generic;
using Gameplay.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Village
{
    [CreateAssetMenu(fileName = "HeadmanDialogues", menuName = "Dialogues/Headman", order = 0)]
    public class HeadmanDialogues : ScriptableObject, IDialogues
    {
        [SerializeField] private Dialogue[] dialogues;
        [SerializeField, TextArea(2, 4)] private string resultText;
        [SerializeField] private Sprite portrait;
       
        public Sprite Portrait => portrait;
        public IReadOnlyList<Dialogue> Dialogues => dialogues;
        public string ResultText => resultText;
    }
}