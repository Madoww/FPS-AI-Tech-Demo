using UnityEngine;

namespace FPS.Game.Scenes
{
    [CreateAssetMenu(menuName = "FPS/Scenes/Scene Dependency Group")]
    public class SceneDependencyGroup : ScriptableObject
    {
        public string title;
        public SerializedScene[] scenes;
    }
}