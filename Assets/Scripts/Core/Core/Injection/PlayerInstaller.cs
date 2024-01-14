using FPS.Common.Injection;
using FPS.Core.Player;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace FPS.Core.Injection
{
    public class PlayerInstaller : ExposableInstaller
    {
        [SerializeField]
        private PlayerController playerController;

        protected override void InstallBindings(DiContainer container)
        {
            Assert.IsNotNull(playerController);

            container.Bind<IPlayerController>()
                .FromInstance(playerController)
                .AsSingle();
        }
    }
}