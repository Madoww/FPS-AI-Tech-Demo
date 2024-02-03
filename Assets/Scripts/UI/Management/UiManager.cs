using FPS.Common;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.UI.Management
{
    public class UiManager : StandaloneManager, IUiManager
    {
        [SerializeField, ReorderableList]
        private List<UiHandlerBehaviour> handlers;

        public IReadOnlyList<IUiHandler> Handlers => handlers;

        private void Update()
        {
            if (!IsInitialized)
            {
                return;
            }

            foreach (var handler in Handlers)
            {
                if (!handler.IsTickable)
                {
                    continue;
                }

                handler.Tick();
            }
        }

        public override void OnInitialize()
        {
            base.OnInitialize();
            foreach (var handler in Handlers)
            {
                if (handler == null)
                {
                    Debug.LogWarning("UiHandler is null.");
                    continue;
                }

                handler.Initialize();
            }
        }

        public override void OnDeinitialize()
        {
            base.OnDeinitialize();
            foreach (var handler in Handlers)
            {
                if (handler == null)
                {
                    continue;
                }

                handler.Deinitialize();
            }
        }
    }
}