using System.Collections.Generic;
using UnityEngine;

namespace FPS.Core.Prefabs.Entities
{
    using FPS.Core.Entities;

    public class EntitiesPrefabsProvider : IPrefabsProvider
    {
        [SerializeField]
        private List<GameEntity> prefabs;

        public IReadOnlyCollection<PrefabData> GetPrefabs()
        {
            var prefabDatas = new List<PrefabData>();
            foreach (var prefab in prefabs)
            {
                var prefabData = new PrefabData()
                {
                    guid = prefab.Guid,
                    prefab = prefab.gameObject
                };
                prefabDatas.Add(prefabData);
            }

            return prefabDatas;
        }
    }
}