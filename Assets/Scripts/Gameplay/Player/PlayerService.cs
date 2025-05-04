using System;
using Cysharp.Threading.Tasks;
using Infrastructure;
using Infrastructure.States;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerService
    {
        private readonly GameStateMachine _stateMachine;
        private int _health;
        private int _attention;

        public int MaxHealth { get; private set; }
        public int Items { get; private set; }
        public PlayerEvolve CurrentEvolve { get; private set; }
        
        public int Health
        {
            get => _health;
            private set => _health = value < 0 ? 0 : value;
        }
        
        public int Attention
        {
            get => _attention;
            private set => _attention = value > CurrentEvolve.MaxAttention ? CurrentEvolve.MaxAttention : value;
        }

        public PlayerService(GameStateMachine gameStateMachine)
        {
            _stateMachine = gameStateMachine;
        }
        
        public async UniTask VisitHome(EnemyType type)
        {
            var effect = CurrentEvolve.GetEnemyEffect(type);
            Health -= effect.damage;
            if (Health == 0)
                await _stateMachine.Enter<HpEndingState>();
            Attention += effect.attention;
            if (Attention == CurrentEvolve.MaxAttention)
                await _stateMachine.Enter<HpEndingState>();
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