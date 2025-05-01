using Cysharp.Threading.Tasks;

namespace Infrastructure.UpdateManagers.Interfaces
{
    /// <summary>
    /// Асинхронный оптимизированный аналог FixedUpdate()
    /// </summary>
    public interface IAsyncFixTick
    {
        UniTask FixTick();
    }
}