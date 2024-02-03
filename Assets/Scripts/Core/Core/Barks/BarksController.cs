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

        public void PlayBark(BarkData barkData)
        {
            OnBarkTriggered?.Invoke(barkData);
        }

        private void Initialize()
        {
            foreach (var processor in processors)
            {
                processor.Initialize();
                processor.OnTrigerred += PlayBark;
            }
        }

        private void Deinitialzie()
        {
            foreach (var processor in processors)
            {
                processor.OnTrigerred -= PlayBark;
                processor.Deinitialize();
            }
        }
    }
}