using FPS.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FPS.Game.Scenes
{
    public class LoadProcessor : ILoadProcessor
    {
        public event Action OnFinished;

        private SceneDefinition currentLoadDefinition;
        private AsyncOperation currentLoadOperation;
        private int loadedScenesCount;
        private int scenesToLoadCount;

        public bool IsLoading => currentLoadDefinition != null;
        public float Progress
        {
            get
            {
                if (IsLoading == false)
                {
                    return 0;
                }

                var currentLoadingProgress = loadedScenesCount + currentLoadOperation.progress;
                var relativeLoadingProgress = currentLoadingProgress / scenesToLoadCount;
                return relativeLoadingProgress;
            }
        }

        public Coroutine LoadDefinition(SceneDefinition sceneDefinition, in SceneDefinitionLoadSettings loadSettings)
        {
            return CoroutineRunner.StartCoroutine(LoadDefinitionCR(sceneDefinition, loadSettings));
        }

        public void CompleteLoading()
        {
            if (IsLoading == false)
            {
                return;
            }

            currentLoadDefinition = null;
        }

        private IEnumerator LoadDefinitionCR(SceneDefinition sceneDefinition, SceneDefinitionLoadSettings loadSettings)
        {
            if (loadSettings.offsetSeconds > 0)
            {
                yield return new WaitForSeconds(loadSettings.offsetSeconds);
            }

            currentLoadDefinition = sceneDefinition;
            loadedScenesCount = 0;
            scenesToLoadCount = sceneDefinition.GetAllLoadableScenes().Count;

            var sceneIndexesToUnload = GetScenesToUnload(sceneDefinition, loadSettings.ignoreLoadedScenes);
            foreach (var sceneIndexToUnload in sceneIndexesToUnload)
            {
                yield return ScenesLoadingUtility.UnloadSceneAsync(sceneIndexToUnload);
            }

            foreach (var scene in sceneDefinition.GetLoadableDependentScenes())
            {
                if (!ScenesLoadingUtility.IsSceneLoaded(scene))
                {
                    currentLoadOperation = ScenesLoadingUtility.LoadSceneAsync(scene, LoadSceneMode.Additive);
                    yield return currentLoadOperation;
                }

                loadedScenesCount++;
            }

            var mainScene = sceneDefinition.mainScene;
            if (!ScenesLoadingUtility.IsSceneLoaded(mainScene))
            {
                currentLoadOperation = ScenesLoadingUtility.LoadSceneAsync(mainScene, LoadSceneMode.Additive);
                yield return currentLoadOperation;

                var mainSceneObject = SceneManager.GetSceneByBuildIndex(mainScene.BuildIndex);
                SceneManager.SetActiveScene(mainSceneObject);
            }

            loadedScenesCount++;
            CompleteLoading();
            OnFinished?.Invoke();
        }

        private List<int> GetScenesToUnload(SceneDefinition sceneDefinition, bool ignoreLoadedScenes)
        {
            var scenesToUnloadIndexes = new List<int>();
            var definitionLoadableScenes = sceneDefinition.GetAllLoadableScenes();
            var definitionLoadableScenesIndexes = definitionLoadableScenes.Select(scene => scene.BuildIndex).ToArray();
            foreach (var loadedScene in ScenesLoadingUtility.GetLoadedScenes())
            {
                var loadedSceneBuildIndex = loadedScene.buildIndex;
                if (loadedSceneBuildIndex == loadedScene.buildIndex)
                {
                    continue;
                }

                bool isInDefinition = definitionLoadableScenesIndexes.Contains(loadedSceneBuildIndex);
                if (!isInDefinition || (isInDefinition && ignoreLoadedScenes))
                {
                    scenesToUnloadIndexes.Add(loadedSceneBuildIndex);
                }
            }

            return scenesToUnloadIndexes;
        }
    }
}