using System.Collections.Generic;
using UnityEngine;

namespace FPS.Prefabs
{
    public class PrefabsManager : MonoBehaviour, IPrefabsManager
    {
        [SerializeField]
        private bool selfInitialize;
        [SerializeReference, ReferencePicker]
        private List<IPrefabsProvider> prefabsProviders;

        private readonly Dictionary<string, GameObject> prefabsByGuid = new Dictionary<string, GameObject>();

        private void Awake()
        {
            if (selfInitialize)
            {
                Initialize();
            }
        }

        public void Initialize()
        {
            List<PrefabData> prefabDatas = new List<PrefabData>();
            foreach (var provider in prefabsProviders)
            {
                prefabDatas.AddRange(provider.GetPrefabs());
            }

            foreach (var prefabData in prefabDatas)
            {
                var guid = prefabData.guid;
                var prefab = prefabData.prefab;
                prefabsByGuid.Add(guid, prefab);
            }
        }

        public bool TryGetPrefab<T>(string guid, out T prefab)
        {
            if (prefabsByGuid.TryGetValue(guid, out GameObject prefabObject))
            {
                prefab = prefabObject.GetComponent<T>();
                return true;
            }

            prefab = default;
            return false;
        }
    }
}