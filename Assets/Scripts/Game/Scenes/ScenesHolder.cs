using FPS.Game.Scenes;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FPS/Scenes/Scenes Holder")]
public class ScenesHolder : ScriptableObject, IScenesHolder
{
    public IReadOnlyList<SceneDefinition> SceneDefinitions => sceneDefinitions;

    [SerializeField, ReorderableList]
    private List<SceneDefinition> sceneDefinitions;

    public void AppendDefinition(SceneDefinition sceneDefinition)
    {
        sceneDefinitions.Add(sceneDefinition);
    }

    public bool RemoveDefinition(SceneDefinition sceneDefinition)
    {
        return sceneDefinitions.Remove(sceneDefinition);
    }

    public bool HasDefinition(SceneDefinition sceneDefinition)
    {
        return sceneDefinitions.Contains(sceneDefinition);
    }

    public bool TryGetAsset(string sceneName, out SceneDefinition sceneDefinition)
    {
        foreach (SceneDefinition definition in sceneDefinitions)
        {
            if (definition == null)
            {
                continue;
            }

            var formattedMainSceneName = definition.mainScene.SceneName.ToLower().Trim();
            var formattedSearchedSceneName = sceneName.ToLower().Trim();
            if (formattedMainSceneName.Contains(formattedSearchedSceneName))
            {
                sceneDefinition = definition;
                return true;
            }
        }

        sceneDefinition = null;
        return false;
    }
}
