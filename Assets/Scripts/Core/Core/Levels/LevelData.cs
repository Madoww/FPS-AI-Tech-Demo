using FMODUnity;
using UnityEngine;

namespace FPS.Core.Levels
{
    [CreateAssetMenu(menuName = "Levels/Level Data")]
    public class LevelData : ScriptableObject
    {
        public SerializedScene scene;
        public EventReference ambienceMusic;
    }
}