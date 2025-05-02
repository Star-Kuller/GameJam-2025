using System;
using Cysharp.Threading.Tasks;
using Gameplay;
using Gameplay.Player;

namespace Infrastructure.States
{
    public class InformState : IState
    {
        private readonly PlayerService _playerService;

        public InformState(PlayerService playerService)
        {
            _playerService = playerService;
        }
        
        public async UniTask OnEnter()
        {
            if (_playerService.CurrentEvolve.TargetItemCount >= _playerService.Items)
                NextEvolve();
        }

        private void NextEvolve()
        {
            switch (_playerService.CurrentEvolve.Evolve)
            {
                case Evolve.Igosha:
                    _playerService.ChangeEvolve(Evolve.Kikimora);
                    break;
                case Evolve.Kikimora:
                    _playerService.ChangeEvolve(Evolve.WhiteHag);
                    break;
                case Evolve.WhiteHag:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}