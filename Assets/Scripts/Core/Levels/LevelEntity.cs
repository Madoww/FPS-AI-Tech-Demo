using FPS.Core.Entities;
using UnityEngine;

namespace FPS.Core.Levels
{
    public class LevelEntity : GameEntity
    {
        [SerializeField]
        private LevelData levelData;

        public LevelData LevelData => levelData;
    }
}