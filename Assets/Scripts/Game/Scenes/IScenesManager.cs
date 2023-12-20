namespace FPS.Game.Scenes
{
    public interface IScenesManager
    {
        bool IsLoading { get; }
        float LoadingProgress { get; }
        float LoadingProgressPercent { get; }

        void LoadDefinition(SceneDefinition sceneDefinition);
        void LoadDefinition(string mainSceneName);
        void LoadDefinitionAndWait(SceneDefinition sceneDefinition);
        void LoadDefinitionAndWait(string mainSceneName);
    }
}