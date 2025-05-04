using System.Collections.Generic;
using Gameplay.Player;
using UnityEngine;

namespace Gameplay.Village
{
    [CreateAssetMenu(fileName = "GroupDialogues", menuName = "Dialogues/Group", order = 0)]
    public class GroupDialogues : ScriptableObject
    {
        [SerializeField] private Evolve evolve;
        [SerializeField] private EnemyDialogues[] dialogues;

        public IReadOnlyCollection<EnemyDialogues> Dialogues => dialogues;
        public Evolve Evolve => evolve;
    }
}