namespace FPS.Core.Cutscenes
{
    public interface IDataProvidersHandler
    {
        bool TryGetProvider<T>(string guid, out T provider) where T : ICutsceneDataProvider;
        bool TryGetGlobalProvider<T>(out T provider) where T : ICutsceneDataProvider;
        bool TryGetSpecificProvider<T>(string guid, out T provider) where T : ICutsceneDataProvider;
    }
}