namespace FPS.Core.Cutscenes
{
    public interface IDataProvidersHandler
    {
        bool TryGetProvider<T>(out T provider) where T : ICutsceneDataProvider;
        bool TryGetProvider<T>(string guid, out T provider) where T : ICutsceneDataProvider;
    }
}