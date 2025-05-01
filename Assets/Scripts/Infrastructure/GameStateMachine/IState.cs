using Cysharp.Threading.Tasks;

namespace Infrastructure
{
    /// <summary>
    /// Это интерфейс игрового состояния
    /// </summary>
    public interface IState
    { 
        /// <summary>
        /// Это метод вызывается при входе в состояние
        /// </summary>
        UniTask OnEnter();
    }
}