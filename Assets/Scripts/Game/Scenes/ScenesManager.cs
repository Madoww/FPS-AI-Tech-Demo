using UnityEngine;

namespace FPS.Game.Scenes
{
    public class ScenesManager : MonoBehaviour, IScenesManager
    {
        [SerializeField]
        private ScenesHolder scenesHolder;

        private readonly SerializedDictionary<string, SceneDefinition> sceneDefinitionByMainSceneName = new SerializedDictionary<string, SceneDefinition>();

        private ILoadProcessor currentLoadProcessor;
        private SceneDefinitionLoadSettings currentLoadSettings;

        public bool IsLoading => throw new System.NotImplementedException();

        public float LoadingProgress => throw new System.NotImplementedException();

        public float LoadingProgressPercent => throw new System.NotImplementedException();

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

        public void LoadDefinitionAndWait(SceneDefinition sceneDefinition)
        {
            throw new System.NotImplementedException();
        }

        public void LoadDefinitionAndWait(string mainSceneName)
        {
            throw new System.NotImplementedException();
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