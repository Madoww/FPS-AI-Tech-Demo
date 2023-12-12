using UnityEngine;
using Zenject;

namespace FPS.AI
{
    using FPS.AI.Detection;
    using FPS.Common.Injection;
    using UnityEngine.Assertions;

    public class AiInstaller : ExposableInstaller
    {
        [SerializeField]
        private DetectableTargetsManager detectableTargetsManager;

        protected override void InstallBindings(DiContainer container)
        {
            Assert.IsNotNull(detectableTargetsManager);

            container.Bind<IDetectableTargetsManager>()
                .FromInstance(detectableTargetsManager)
                .AsSingle();
        }
    }
}