using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace FPS.Common
{
    public abstract class ScriptableNodesHolder : ScriptableObject
    {
        [ReorderableList]
        public List<ScriptableNode> nodes;

        public void AppendNode(ScriptableNode node)
        {
            nodes.Add(node);
            AssetDatabase.AddObjectToAsset(node, this);
            AssetDatabase.SaveAssets();
        }

        public T AppendNode<T>() where T : ScriptableNode
        {
            T node = ScriptableObject.CreateInstance<T>();
            AppendNode(node);
            return node;
        }

        public bool RemoveNode(ScriptableNode node)
        {
            AssetDatabase.RemoveObjectFromAsset(node);
            AssetDatabase.SaveAssets();
            return nodes.Remove(node);
        }
    }
}