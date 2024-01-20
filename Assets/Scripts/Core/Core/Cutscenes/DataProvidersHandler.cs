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

        public bool TryGetProvider<T>(string guid, out T provider) where T : ICutsceneDataProvider
        {
            return TryGetSpecificProvider<T>(guid, out provider)
                || TryGetGlobalProvider<T>(out provider);
        }

        public bool TryGetGlobalProvider<T>(out T provider) where T : ICutsceneDataProvider
        {
            foreach (ICutsceneDataProvider dataProvider in dataProviders)
            {
                if(dataProvider.IsGuidSpecific)
                {
                    continue;
                }

                if (dataProvider is T)
                {
                    provider = (T)dataProvider;
                    return true;
                }
            }

            provider = default(T);
            return false;
        }

        public bool TryGetSpecificProvider<T>(string guid, out T provider) where T : ICutsceneDataProvider
        {
            foreach (ICutsceneDataProvider dataProvider in dataProviders)
            {
                if(dataProvider.ReferenceGuid != guid)
                {
                    continue;
                }

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