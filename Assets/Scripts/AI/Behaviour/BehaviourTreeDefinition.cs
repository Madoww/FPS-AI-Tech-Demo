using FPS.Common;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.AI.Behaviour
{
    [CreateAssetMenu(menuName = "FPS/Behaviour/Behaviour Tree Definition")]
    public class BehaviourTreeDefinition : ScriptableNodesHolder<BehaviourNodeData>
    {
        public bool GetNode<T>(out T data) where T : BehaviourNodeData
        {
            foreach (BehaviourNodeData nodeData in Nodes)
            {
                if (nodeData is T)
                {
                    data = nodeData as T;
                    return true;
                }
            }

            data = null;
            return false;
        }

        public List<T> GetAllNodes<T>() where T : BehaviourNodeData
        {
            var nodes = new List<T>();
            foreach (BehaviourNodeData nodeData in Nodes)
            {
                if (nodeData is T tNodeData)
                {
                    nodes.Add(tNodeData);
                }
            }

            return nodes;
        }
    }
}