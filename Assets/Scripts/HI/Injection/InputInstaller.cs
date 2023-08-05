using UnityEngine;
using Zenject;

namespace FPS.HI.Injection
{
    using FPS.Common.Injection;
    using FPS.HI.Input;
    using FPS.HI.Input.Handlers;

    public class InputInstaller : ExposableInstaller
    {
        [SerializeReference]
        private PlayerMovementController playerMovementController;

        protected override void InstallBindings(DiContainer container)
        {
            container.Bind<IPlayerInputHandler>()
                .To<PlayerInputHandler>()
                .AsSingle();

            container.Bind<IPlayerMovementController>()
                .FromInstance(playerMovementController)
                .AsSingle();

            container.Bind<PlayerControls>()
                .AsSingle();
        }
    }
}