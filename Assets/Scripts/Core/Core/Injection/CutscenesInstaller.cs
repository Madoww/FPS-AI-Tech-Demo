using FPS.Common.Injection;
using FPS.Core.Cutscenes.Management;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace FPS.Core.Injections
{
    public class CutscenesInstaller : ExposableInstaller
    {
        [SerializeField]
        private CutscenesManager cutscenesManager;
        [SerializeField]
        private CutscenesController cutscenesController;

        protected override void InstallBindings(DiContainer container)
        {
            Assert.IsNotNull(cutscenesManager);
            Assert.IsNotNull(cutscenesController);

            container.Bind<ICutscenesManager>()
                .FromInstance(cutscenesManager)
                .AsSingle();
            container.Bind<ICutscenesController>()
                .FromInstance(cutscenesController)
                .AsSingle();
        }
    }
}