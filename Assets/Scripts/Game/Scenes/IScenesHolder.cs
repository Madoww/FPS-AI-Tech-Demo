using System.Collections.Generic;

namespace FPS.Game.Scenes
{
    public interface IScenesHolder
    {
        IReadOnlyList<SceneDefinition> SceneDefinitions { get; }

        void AppendDefinition(SceneDefinition sceneDefinition);
        bool RemoveDefinition(SceneDefinition sceneDefinition);
        bool HasDefinition(SceneDefinition sceneDefinition);
        bool TryGetAsset(string sceneName, out SceneDefinition sceneDefinition);
    }
}