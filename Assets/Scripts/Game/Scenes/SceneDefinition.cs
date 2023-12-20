using System.Collections.Generic;
using UnityEngine;

namespace FPS.Game.Scenes
{
    [CreateAssetMenu(fileName = "Scene Definition", menuName = "Scenes/Scene Definition")]
    public class SceneDefinition : ScriptableObject
    {
        public string displayName;
        public string description;
        public SerializedScene mainScene;
        public SceneDependencyGroup[] dependencyGroups;

        public IList<SerializedScene> GetAllLoadableScenes()
        {
            var allScenesToLoad = new List<SerializedScene>()
            {
                mainScene
            };
            allScenesToLoad.AddRange(GetLoadableDependentScenes());

            return allScenesToLoad;
        }

        public IList<SerializedScene> GetLoadableDependentScenes()
        {
            var loadableScenes = new List<SerializedScene>();
            foreach (var group in dependencyGroups)
            {
                loadableScenes.AddRange(group.scenes);
            }

            return loadableScenes;
        }
    }
}