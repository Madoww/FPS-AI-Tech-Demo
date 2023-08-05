namespace FPS.HI.Input
{
    using static FPS.HI.Input.PlayerControls;

    public interface IPlayerInputHandler : IOnFootActions
    {
        void Enable();
        void Disable();
    }
}