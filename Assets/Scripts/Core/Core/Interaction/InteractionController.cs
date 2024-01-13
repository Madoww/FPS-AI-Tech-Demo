using FPS.Common;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Core.Interaction
{
    public class InteractionController : StandaloneManager, IInteractionController
    {
        [SerializeReference, ReferencePicker, ReorderableList]
        private List<IInteractionProcessor> processors;

        public IReadOnlyList<IInteractionProcessor> Processors => processors;

        //TODO: Add input handler.
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                TryInteract();
            }
        }

        public override void OnInitialize()
        {
            base.OnInitialize();
            InitializeProcessors();
        }

        public override void OnDeinitialize()
        {
            DeinitializeProcessors();
            base.OnDeinitialize();
        }

        public void TryInteract()
        {
            if (!Physics.Raycast(transform.position, Camera.main.transform.forward, out var hitInfo))
            {
                return;
            }

            var collider = hitInfo.collider;
            if (!collider.TryGetComponent<Interactable>(out var interactable))
            {
                return;
            }

            ProcessInteractable(interactable);
        }

        private void InitializeProcessors()
        {
            foreach (var processor in processors)
            {
                processor.Initialize();
            }
        }

        private void DeinitializeProcessors()
        {
            foreach (var processor in processors)
            {
                processor.Deinitialize();
            }
        }

        private void ProcessInteractable(Interactable interactable)
        {
            foreach (var processor in processors)
            {
                processor.Process(interactable);
            }
        }
    }
}