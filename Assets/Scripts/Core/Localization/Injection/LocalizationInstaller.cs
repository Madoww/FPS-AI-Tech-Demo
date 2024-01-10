using FPS.Common.Injection;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace FPS.Localization.Injection
{
    public class LocalizationInstaller : ExposableInstaller
    {
        [SerializeField]
        private LocalizationController localizationController;

        protected override void InstallBindings(DiContainer container)
        {
            Assert.IsNotNull(localizationController);

            container.Bind<ILocalizationController>()
                .FromInstance(localizationController)
                .AsSingle();

            var processors = localizationController.Processors;
            foreach (var processor in processors)
            {
                if (processor == null)
                {
                    continue;
                }

                container.QueueForInject(processor);
            }
        }
    }
}