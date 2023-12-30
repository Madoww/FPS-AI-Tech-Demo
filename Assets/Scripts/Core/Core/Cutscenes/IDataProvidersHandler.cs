namespace FPS.Core.Cutscenes
{
    public interface IDataProvidersHandler
    {
        bool TryGetProvider<T>(out T provider) where T : ICutsceneDataProvider;
    }
}