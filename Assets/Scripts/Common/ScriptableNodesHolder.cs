using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace FPS.Common
{
    public abstract class ScriptableNodesHolder : ScriptableObject
    {
        [ReorderableList]
        public List<ScriptableNode> nodes;

        public virtual void AppendNode(ScriptableNode node)
        {
            var nodeType = node.GetType();
            node.displayName = nodeType.Name;
            nodes.Add(node);
            AssetDatabase.AddObjectToAsset(node, this);
            AssetDatabase.SaveAssets();
        }

        public virtual ScriptableNode AppendNode(Type type)
        {
            ScriptableNode node = (ScriptableNode)ScriptableObject.CreateInstance(type);
            AppendNode(node);
            return node;
        }

        public virtual bool RemoveNode(ScriptableNode node)
        {
            AssetDatabase.RemoveObjectFromAsset(node);
            AssetDatabase.SaveAssets();
            return nodes.Remove(node);
        }
    }

    public abstract class ScriptableNodesHolder<T> : ScriptableNodesHolder where T : ScriptableNode
    {
        public List<T> Nodes => nodes.Cast<T>().ToList();
    }
}