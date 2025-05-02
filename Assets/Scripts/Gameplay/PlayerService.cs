using System;
using Cysharp.Threading.Tasks;
using Infrastructure;
using Infrastructure.States;
using UnityEngine;

namespace Gameplay
{
    public class PlayerService
    {
        private readonly GameStateMachine _stateMachine;
        public int Health { get; private set; }
        public int Attention { get; private set; }
        public int Items { get; private set; }
        public PlayerEvolve CurrentEvolve { get; private set; }
        

        public async UniTask HomeVisit(EnemyType type)
        {
            var effect = CurrentEvolve.GetEnemyEffect(type);
            Health -= effect.damage;
            Attention += effect.attention;
            if (Health <= 0 || Attention >= CurrentEvolve.MaxAttention)
                await _stateMachine.Enter<DeadState>();
            Items += effect.items;
        }

        public void ChangeState(Evolve evolve)
        {
            CurrentEvolve = evolve switch
            {
                Evolve.Igosha => Resources.Load<PlayerEvolve>("Igosha"),
                Evolve.Kikimora => Resources.Load<PlayerEvolve>("Kikimora"),
                Evolve.WhiteHag => Resources.Load<PlayerEvolve>("WhiteHag"),
                _ => throw new ArgumentOutOfRangeException(nameof(evolve), evolve, null)
            };
            Health += CurrentEvolve.MaxHealth;
            Items = 0;
        }
    }
}