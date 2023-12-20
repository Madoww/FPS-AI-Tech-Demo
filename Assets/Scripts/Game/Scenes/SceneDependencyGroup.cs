using UnityEngine;

namespace FPS.Game.Scenes
{
    [CreateAssetMenu(fileName = "Scene Dependency Group", menuName = "Scenes/Scene Dependency Group")]
    public class SceneDependencyGroup : ScriptableObject
    {
        public string title;
        public SerializedScene[] scenes;
    }
}