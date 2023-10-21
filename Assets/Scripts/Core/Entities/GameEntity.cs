using UnityEngine;

namespace FPS.Core.Entities
{
    public abstract class GameEntity : MonoBehaviour
    {
        public string Guid { get; private set; }

        private void Reset()
        {
            Guid = System.Guid.NewGuid().ToString();
        }
    }
}