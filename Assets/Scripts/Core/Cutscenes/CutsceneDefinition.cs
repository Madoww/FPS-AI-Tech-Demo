using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace FPS.Cutscenes
{
    [CreateAssetMenu(menuName = "Cutscenes/Cutscene Definition")]
    public class CutsceneDefinition : ScriptableObject
    {
        public string displayName;
        [ReorderableList]
        public List<CutsceneNodeDefinition> nodes;

        public void AppendNode(CutsceneNodeDefinition node)
        {
            nodes.Add(node);
            AssetDatabase.AddObjectToAsset(node, this);
            AssetDatabase.SaveAssets();
        }

        public T AppendNode<T>() where T : CutsceneNodeDefinition
        {
            T node = ScriptableObject.CreateInstance<T>();
            AppendNode(node);
            return node;
        }

        public bool RemoveNode(CutsceneNodeDefinition node)
        {
            AssetDatabase.RemoveObjectFromAsset(node);
            AssetDatabase.SaveAssets();
            return nodes.Remove(node);
        }
    }
}