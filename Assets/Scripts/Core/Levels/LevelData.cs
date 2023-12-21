using FMODUnity;
using UnityEngine;

namespace FPS.Core.Levels
{
    [CreateAssetMenu(menuName = "Levels/Level Data")]
    public class LevelData : ScriptableObject
    {
        public EventReference ambienceMusic;
    }
}