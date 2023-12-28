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

        public T TryGetProvider<T>() where T : ICutsceneDataProvider
        {
            foreach (ICutsceneDataProvider provider in dataProviders)
            {
                if (provider is T)
                {
                    return (T)provider;
                }
            }

            return default(T);
        }
    }
}