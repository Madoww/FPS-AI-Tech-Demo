using UnityEngine;
using Zenject;

namespace FPS.Game.Injection
{
    using FPS.Common.Injection;
    using FPS.Game.Scenes;
    using UnityEngine.Assertions;

    public class ScenesInstaller : ExposableInstaller
    {
        [SerializeField]
        private ScenesManager scenesManager;

        protected override void InstallBindings(DiContainer container)
        {
            Assert.IsNotNull(scenesManager);

            container.Bind<IScenesManager>()
                .FromInstance(scenesManager)
                .AsSingle();
        }
    }
}