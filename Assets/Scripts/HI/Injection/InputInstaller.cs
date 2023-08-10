using Zenject;

namespace FPS.HI.Injection
{
    using FPS.Common.Injection;
    using FPS.HI.Input;
    using FPS.HI.Input.Handlers;

    public class InputInstaller : ExposableInstaller
    {
        protected override void InstallBindings(DiContainer container)
        {
            container.Bind<IPlayerInputHandler>()
                .To<PlayerInputHandler>()
                .AsSingle();

            container.Bind<PlayerControls>()
                .AsSingle();
        }
    }
}