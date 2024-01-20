using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FPS.Common;
using UnityEditor;

namespace FPS.Editor.GraphEditor
{
    //TODO: Replace with an actual file save.
    [CreateAssetMenu(menuName = "FPS/Cutscenes/Editor/Node Positions Holder")]
    public class NodePositionsHolder : ScriptableObject
    {
        private readonly Dictionary<ScriptableNode, Vector2> positionsByNode = new Dictionary<ScriptableNode, Vector2>();

        public void StorePosition(ScriptableNode node, Vector2 position)
        {
            if (!positionsByNode.ContainsKey(node))
            {
                positionsByNode.Add(node, position);
                return;
            }

            positionsByNode[node] = position;
            AssetDatabase.SaveAssets();
        }

        public Vector2 GetPosition(ScriptableNode node)
        {
            if (!positionsByNode.ContainsKey(node))
            {
                return Vector2.zero;
            }

            return positionsByNode[node];
        }
    }
}