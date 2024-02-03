namespace FPS.UI
{
    public interface IUiHandler : ITickable
    {
        bool IsTickable { get; }

        void Initialize();
        void Deinitialize();
    }
}