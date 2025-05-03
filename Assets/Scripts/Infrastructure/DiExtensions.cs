using System.Linq;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure
{
    public static class DiExtensions
    {
        public static DiContainer GetSceneContainer(this Scene scene)
        {
            var sceneContext = scene.GetRootGameObjects()
                .First(x => x.name == "SceneContext");
            return sceneContext.GetComponent<SceneContext>().Container;
        }
    }
}