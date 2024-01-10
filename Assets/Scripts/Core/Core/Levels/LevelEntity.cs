using FPS.Common;
using FPS.Entities;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FPS.Core.Levels
{
    public class LevelEntity : GameEntity
    {
        [SerializeField]
        private LevelData levelData;

        public LevelData LevelData => levelData;

        private void Start()
        {
            SetLevelSceneAsActive();
        }

        private void SetLevelSceneAsActive()
        {
            var levelScene = levelData.scene;
            var currentScene = SceneManager.GetSceneByBuildIndex(levelScene.BuildIndex);
            CoroutineRunner.StartCoroutine(WaitToLoadAndSetActive());

            IEnumerator WaitToLoadAndSetActive()
            {
                while (currentScene.isLoaded == false)
                {
                    yield return null;
                }

                SceneManager.SetActiveScene(currentScene);
            }
        }
    }
}