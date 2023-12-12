using System.Collections.Generic;
using UnityEngine;

namespace FPS.Core.Entities.Management
{
    public class EntitiesManager : MonoBehaviour, IEntitiesManager
    {
        private Dictionary<string, GameEntity> entities = new Dictionary<string, GameEntity>();

        public void AppendEntity(GameEntity entity)
        {
            var guid = entity.Guid;
            if (entities.ContainsKey(guid))
            {
                Debug.LogError($"Entity with guid {guid} was already registered.");
                return;
            }

            entities.Add(guid, entity);
        }

        public void RemoveEntity(GameEntity entity)
        {
            RemoveEntity(entity.Guid);
        }

        public void RemoveEntity(string guid)
        {
            entities.Remove(guid);
        }

        public GameEntity GetEntity(string guid)
        {
            if (entities.TryGetValue(guid, out GameEntity entity))
            {
                return entity;
            }

            Debug.LogError($"[Core][Entities] Entity with guid {guid} not found.");
            return null;
        }
    }
}