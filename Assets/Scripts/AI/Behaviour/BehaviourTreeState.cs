using System.Collections.Generic;
using UnityEngine;

namespace FPS.AI.Behaviour
{
    public class BehaviourTreeState
    {
        private Dictionary<string, object> data;
        private Dictionary<Node, Node> runningChildByNodes;

        public BehaviourTreeState()
        {
            data = new Dictionary<string, object>();
            runningChildByNodes = new Dictionary<Node, Node>();
        }

        public void SetData(string key, object value)
        {
            if (!data.ContainsKey(key))
            {
                data.Add(key, value);
                return;
            }

            data[key] = value;
        }

        public bool TryGetData<T>(string key, out T value)
        {
            if (data.ContainsKey(key))
            {
                value = (T)data[key];
                return true;
            }

            value = default;
            return false;
        }

        public void ResetRunningChildren()
        {
            runningChildByNodes.Clear();
        }

        public void RegisterRunningChild(Node parent, Node child)
        {
            if (runningChildByNodes.ContainsKey(parent))
            {
                Debug.LogWarning("[AI] Node was already registered as running.");
                return;
            }

            runningChildByNodes.Add(parent, child);
        }

        public void UnregisterRunningChild(Node parent)
        {
            if (!runningChildByNodes.ContainsKey(parent))
            {
                Debug.LogWarning("[AI] Node was not registered as running.");
                return;
            }

            runningChildByNodes.Remove(parent);
        }

        public bool TryGetRunningChild(Node parent, out Node runningChild)
        {
            if (!runningChildByNodes.ContainsKey(parent))
            {
                runningChild = null;
                return false;
            }

            runningChild = runningChildByNodes[parent];
            return true;
        }
    }
}