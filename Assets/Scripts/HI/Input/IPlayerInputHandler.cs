using Zenject;

namespace FPS.HI.Input
{
    using static FPS.HI.Input.PlayerControls;

    public interface IPlayerInputHandler : IOnFootActions, ITickable
    {
        void Enable();
        void Disable();
    }
}