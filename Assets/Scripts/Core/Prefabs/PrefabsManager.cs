using System.Collections.Generic;
using UnityEngine;

namespace FPS.Core.Prefabs
{
    public class PrefabsManager : MonoBehaviour
    {
        [SerializeField]
        private bool selfInitialize;

        [SerializeReference, ReferencePicker]
        private List<IPrefabsProvider> prefabsProviders;

        private readonly List<PrefabData> prefabDatas = new List<PrefabData>();

        private void Awake()
        {
            if (selfInitialize)
            {
                Initialize();
            }
        }

        public void Initialize()
        {
            foreach (var provider in prefabsProviders)
            {
                prefabDatas.AddRange(provider.GetPrefabs());
            }
        }
    }
}