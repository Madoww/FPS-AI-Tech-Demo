using UnityEngine;
using Zenject;

namespace FPS.AI
{
    using FPS.AI.Detection;
    using FPS.Common.Injection;

    public class AiInstaller : ExposableInstaller
    {
        [SerializeField]
        private DetectableTargetsManager detectableTargetsManager;

        protected override void InstallBindings(DiContainer container)
        {
            container.Bind<IDetectableTargetsManager>()
                .FromInstance(detectableTargetsManager)
                .AsSingle();
        }
    }
}