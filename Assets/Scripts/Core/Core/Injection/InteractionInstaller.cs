using FPS.Common.Injection;
using FPS.Core.Interaction;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace FPS.Core.Injection
{
    public class InteractionInstaller : ExposableInstaller
    {
        [SerializeField]
        private InteractionController interactionController;

        protected override void InstallBindings(DiContainer container)
        {
            Assert.IsNotNull(interactionController);

            container.Bind<InteractionController>()
                .FromInstance(interactionController)
                .AsSingle();

            var processors = interactionController.Processors;
            foreach (var processor in processors)
            {
                container.QueueForInject(processor);
            }
        }
    }
}