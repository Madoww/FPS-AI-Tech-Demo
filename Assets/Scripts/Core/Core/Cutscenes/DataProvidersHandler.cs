using System;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Core.Cutscenes
{
    [Serializable]
    public class DataProvidersHandler : IDataProvidersHandler
    {
        [SerializeReference, ReferencePicker, ReorderableList]
        private List<ICutsceneDataProvider> dataProviders;

        public bool TryGetProvider<T>(out T provider) where T : ICutsceneDataProvider
        {
            foreach (ICutsceneDataProvider dataProvider in dataProviders)
            {
                if (dataProvider is T)
                {
                    provider = (T)dataProvider;
                    return true;
                }
            }

            provider = default(T);
            return false;
        }
    }
}