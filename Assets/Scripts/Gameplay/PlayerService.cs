using System;
using Gameplay.PlayerEvolves;
using Zenject;

namespace Gameplay
{
    public class PlayerService
    {
        private readonly DiContainer _container;
        public PlayerService(DiContainer container)
        {
            _container = container;
        }
        
        private IPlayerEvolve CurrentEvolve { get; set; }

        public void ChangeState(PlayerEvolve evolve)
        {
            switch (evolve)
            {
                case PlayerEvolve.Igosha:
                    CurrentEvolve = _container.Resolve<Igosha>();
                    break;
                case PlayerEvolve.Kikimora:
                    break;
                case PlayerEvolve.WhiteHag:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(evolve), evolve, null);
            }
        }
    }
}