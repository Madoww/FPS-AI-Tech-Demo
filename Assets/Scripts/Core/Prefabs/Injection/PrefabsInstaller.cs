using UnityEngine;
using Zenject;

namespace FPS.Prefabs.Injection
{
    using FPS.Common.Injection;

    public class PrefabsInstaller : ExposableInstaller
    {
        [SerializeField]
        private IPrefabsManager prefabsManager;

        protected override void InstallBindings(DiContainer container)
        {
            container.Bind<IPrefabsManager>()
                .FromInstance(prefabsManager)
                .AsSingle();
        }
    }
}