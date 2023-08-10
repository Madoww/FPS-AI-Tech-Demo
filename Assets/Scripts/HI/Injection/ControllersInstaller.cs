using FPS.Common.Injection;
using FPS.HI.Player;
using UnityEngine;
using Zenject;

namespace FPS.HI.Injection
{
    public class ControllersInstaller : ExposableInstaller
    {
        [SerializeReference]
        private PlayerMovementController playerMovementController;
        [SerializeField]
        private PlayerCameraController playerCameraController;

        protected override void InstallBindings(DiContainer container)
        {
            container.Bind<IPlayerMovementController>()
                .FromInstance(playerMovementController)
                .AsSingle();

            container.Bind<IPlayerCameraController>()
                .FromInstance(playerCameraController)
                .AsSingle();
        }
    }
}