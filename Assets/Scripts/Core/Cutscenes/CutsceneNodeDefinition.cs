using System.Collections.Generic;
using UnityEngine;

namespace FPS.Cutscenes
{
    [CreateAssetMenu(menuName = "CutscenesOldOld/Node")]
    public class CutsceneNodeDefinition : ScriptableObject
    {
        public string displayName;
        public string guid;
        public List<CutsceneNodeDefinition> childNodes = new List<CutsceneNodeDefinition>();
        public Vector2 position;

        private void Reset()
        {
            guid = System.Guid.NewGuid().ToString();
        }

        public void AddChild(CutsceneNodeDefinition child)
        {
            childNodes.Add(child);
        }

        public void RemoveChild(CutsceneNodeDefinition child)
        {
            childNodes.Remove(child);
        }
    }
}