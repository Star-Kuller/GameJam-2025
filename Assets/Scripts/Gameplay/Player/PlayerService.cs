using System;
using Cysharp.Threading.Tasks;
using Infrastructure;
using Infrastructure.States;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.Player
{
    public class PlayerService
    {
        private readonly GameStateMachine _stateMachine;
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }
        public int Attention { get; private set; }
        public int Items { get; private set; }
        public PlayerEvolve CurrentEvolve { get; private set; }

        public PlayerService(GameStateMachine gameStateMachine)
        {
            _stateMachine = gameStateMachine;
        }
        
        public async UniTask VisitHome(EnemyType type)
        {
            var effect = CurrentEvolve.GetEnemyEffect(type);
            Health -= effect.damage;
            Attention += effect.attention;
            if (Health <= 0 || Attention >= CurrentEvolve.MaxAttention)
                await _stateMachine.Enter<DeadState>();
            Items += effect.items;
        }

        public void ChangeEvolve(Evolve evolve)
        {
            CurrentEvolve = evolve switch
            {
                Evolve.Igosha => Resources.Load<PlayerEvolve>("Igosha"),
                Evolve.Kikimora => Resources.Load<PlayerEvolve>("Kikimora"),
                Evolve.WhiteHag => Resources.Load<PlayerEvolve>("WhiteHag"),
                _ => throw new ArgumentOutOfRangeException(nameof(evolve), evolve, null)
            };
            Health += CurrentEvolve.MaxHealth;
            MaxHealth = Health;
            Items = 0;

            Debug.Log($"Игрок перешёл на этап {evolve} HP: {Health/MaxHealth} Внимание: {Attention/CurrentEvolve.MaxAttention}");
        }
    }
}