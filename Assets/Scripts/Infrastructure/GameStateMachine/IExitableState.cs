using Cysharp.Threading.Tasks;

namespace Infrastructure
{
    /// <summary>
    /// Это интерфейс игрового состояния, но с методом срабатывающем при выходе из состояния
    /// </summary>
    public interface IExitableState : IState
    {
        /// <summary>
        /// Это метод вызывается при выходе из состояние
        /// </summary>
        UniTask OnExit();
    }
}