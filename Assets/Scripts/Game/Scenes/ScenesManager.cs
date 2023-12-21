using UnityEngine;

namespace FPS.Game.Scenes
{
    public class ScenesManager : MonoBehaviour, IScenesManager
    {
        [SerializeField]
        private ScenesHolder scenesHolder;

        private readonly SerializedDictionary<string, SceneDefinition> sceneDefinitionByMainSceneName = new SerializedDictionary<string, SceneDefinition>();
        private readonly SceneDefinitionLoadSettings currentLoadSettings = new SceneDefinitionLoadSettings()
        {
            ignoreLoadedScenes = true
        };

        private ILoadProcessor currentLoadProcessor;

        public bool IsLoading => currentLoadProcessor != null;
        public float LoadingProgress => currentLoadProcessor.Progress;
        public float LoadingProgressPercent => LoadingProgress * 100f;

        public void LoadDefinition(SceneDefinition sceneDefinition)
        {
            currentLoadProcessor = ScenesLoadingUtility.LoadDefinition(sceneDefinition, currentLoadSettings);
        }

        public void LoadDefinition(string mainSceneName)
        {
            SceneDefinition definition = GetDefinitionByName(mainSceneName);
            if (definition == null)
            {
                return;
            }

            currentLoadProcessor = ScenesLoadingUtility.LoadDefinition(definition, currentLoadSettings);
        }

        private SceneDefinition GetDefinitionByName(string mainSceneName)
        {
            if (sceneDefinitionByMainSceneName.TryGetValue(mainSceneName, out SceneDefinition sceneDefinition))
            {
                return sceneDefinition;
            }

            if (scenesHolder.TryGetAsset(mainSceneName, out sceneDefinition))
            {
                sceneDefinitionByMainSceneName.Add(mainSceneName, sceneDefinition);
                return sceneDefinition;
            }

            return null;
        }
    }
}