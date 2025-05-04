using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Village
{
    public interface IDialogues
    {
        public Sprite Portrait { get; }
        public IReadOnlyList<Dialogue> Dialogues { get; }
        public string ResultText { get; }
    }
}