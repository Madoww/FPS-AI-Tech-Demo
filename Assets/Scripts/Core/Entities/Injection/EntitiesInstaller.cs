using UnityEngine;
using Zenject;

namespace FPS.Core.Entities.Injection
{
    using FPS.Common.Injection;
    using FPS.Core.Entities.Management;

    public class EntitiesInstaller : ExposableInstaller
    {
        [SerializeField]
        private EntitiesManager entitiesManager;

        protected override void InstallBindings(DiContainer container)
        {
            container.Bind<IEntitiesManager>()
                .FromInstance(entitiesManager)
                .AsSingle();
        }
    }
}