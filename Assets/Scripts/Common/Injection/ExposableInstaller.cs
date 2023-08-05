using UnityEngine;
using Zenject;

namespace FPS.Common.Injection
{
    public abstract class ExposableInstaller : MonoInstaller
    {
        [SerializeField]
        private bool bindToParent;

        protected bool BindToParent
        {
            get => bindToParent;
            set => bindToParent = value;
        }

        protected DiContainer ParentContainer { get; private set; }

        public override void InstallBindings()
        {
            var contextContainer = Container;
            ParentContainer = GetParentContainer();
            if (BindToParent)
            {
                if (ParentContainer == null)
                {
                    Debug.LogWarning("Cannot find parent container.");
                }
                else
                {
                    contextContainer = ParentContainer;
                }
            }

            InstallBindings(contextContainer);
        }

        protected abstract void InstallBindings(DiContainer container);

        private DiContainer GetParentContainer()
        {
            var parents = Container.ParentContainers;
            if (parents == null || parents.Length == 0)
            {
                return null;
            }

            return parents[0];
        }
    }
}