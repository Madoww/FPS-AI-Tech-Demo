using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Common
{
    public class ScriptableNode : ScriptableObject
    {
        public string displayName;
        public string guid;
        public List<ScriptableNode> childNodes = new List<ScriptableNode>();
        public Vector2 position;

        private void Reset()
        {
            guid = System.Guid.NewGuid().ToString();
        }

        public void AddChild(ScriptableNode child)
        {
            childNodes.Add(child);
        }

        public void RemoveChild(ScriptableNode child)
        {
            childNodes.Remove(child);
        }
    }
}