using FPS.Common;
using FPS.Core.Cutscenes.Data;
using System;
using UnityEngine;

namespace FPS.Core.Cutscenes
{
    [CreateAssetMenu(menuName = "Cutscenes/Cutscene Definition")]
    public class CutsceneDefinition : ScriptableNodesHolder<CutsceneNodeData>
    {
        public CutsceneNodeData rootNodeData;
        public string displayName;

        public override void AppendNode(ScriptableNode node)
        {
            if (node is RootNodeData rootNodeData)
            {
                if (HasRootNode())
                {
                    Debug.LogWarning("Cutscene already contains a root node");
                    return;
                }

                this.rootNodeData = rootNodeData;
            }

            base.AppendNode(node);
        }

        public override ScriptableNode AppendNode(Type type)
        {
            if (type == typeof(RootNodeData))
            {
                if (HasRootNode())
                {
                    Debug.LogWarning("Cutscene already contains a root node");
                    return null;
                }
            }

            return base.AppendNode(type);
        }

        private bool HasRootNode()
        {
            foreach (CutsceneNodeData nodeData in Nodes)
            {
                if (nodeData is RootNodeData)
                {
                    return true;
                }
            }

            return false;
        }
    }
}