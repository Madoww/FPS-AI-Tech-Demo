using FPS.Common.Injection;
using FPS.Entities.Management;
using UnityEngine;
using Zenject;

namespace FPS.Entities.Injection
{
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