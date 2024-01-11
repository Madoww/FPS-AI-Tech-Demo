using System;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Core.Barks
{
    public class BarksController : MonoBehaviour, IBarksController
    {
        public event Action<BarkData> OnBarkTriggered;

        [SerializeField]
        private bool selfInitialize;
        [SerializeReference, ReferencePicker, ReorderableList]
        private List<IBarkProcessor> processors;

        private void Awake()
        {
            if (selfInitialize)
            {
                Initialize();
            }
        }

        private void OnDestroy()
        {
            Deinitialzie();
        }

        //TODO: Use state machine tick instead of Update.
        private void Update()
        {
            foreach (var processor in processors)
            {
                processor.Process();
            }
        }

        private void Initialize()
        {
            foreach (var processor in processors)
            {
                processor.Initialize();
                processor.OnTrigerred += OnTriggerBark;
            }
        }

        private void Deinitialzie()
        {
            foreach (var processor in processors)
            {
                processor.OnTrigerred -= OnTriggerBark;
                processor.Deinitialize();
            }
        }

        private void OnTriggerBark(BarkData barkData)
        {
            OnBarkTriggered?.Invoke(barkData);
        }
    }
}