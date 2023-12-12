using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace FPS.HI.Injection
{
    using FPS.Common.Injection;
    using FPS.HI.Player;

    public class ControllersInstaller : ExposableInstaller
    {
        [SerializeField]
        private PlayerMovementController playerMovementController;
        [SerializeField]
        private PlayerCameraController playerCameraController;

        protected override void InstallBindings(DiContainer container)
        {
            Assert.IsNotNull(playerMovementController);
            Assert.IsNotNull(playerCameraController);

            container.Bind<IPlayerMovementController>()
                .FromInstance(playerMovementController)
                .AsSingle();

            container.Bind<IPlayerCameraController>()
                .FromInstance(playerCameraController)
                .AsSingle();
        }
    }
}