using Cysharp.Threading.Tasks;

namespace Infrastructure.UpdateManagers.Interfaces
{
    /// <summary>
    /// Асинхронный оптимизированный аналог Update()
    /// </summary>
    public interface IAsyncTick
    {
        UniTask Tick();
    }
}