using FPS.Common;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Core.Cutscenes
{
    [CreateAssetMenu(menuName = "FPS/Cutscenes/Cutscene Definition")]
    public class CutsceneDefinition : ScriptableNodesHolder<CutsceneNodeData>
    {
        public string displayName;

        public bool GetNode<T>(out T data) where T : CutsceneNodeData
        {
            foreach (CutsceneNodeData nodeData in Nodes)
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

        public List<T> GetAllNodes<T>() where T : CutsceneNodeData
        {
            var nodes = new List<T>();
            foreach (CutsceneNodeData nodeData in Nodes)
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