namespace FPS.Core.Cutscenes
{
    public interface IDataProvidersHandler
    {
        T TryGetProvider<T>() where T : ICutsceneDataProvider;
    }
}