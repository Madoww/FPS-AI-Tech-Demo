using FPS.Game.Scenes;
using System.Diagnostics;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ScenesLoadingUtility
{
    public static AsyncOperation LoadSceneAsync(SerializedScene scene, LoadSceneMode loadSceneMode)
    {
#if UNITY_EDITOR
        if (Application.isPlaying == false)
        {
            OpenSceneInEditor(scene, loadSceneMode);
            return null;
        }
#endif
        return SceneManager.LoadSceneAsync(scene.BuildIndex, loadSceneMode);
    }

    public static AsyncOperation UnloadSceneAsync(int buildIndex, UnloadSceneOptions unloadSceneOptions = UnloadSceneOptions.None)
    {
        return SceneManager.UnloadSceneAsync(buildIndex, unloadSceneOptions);
    }

    public static LoadProcessor LoadDefinition(SceneDefinition sceneDefinition, in SceneDefinitionLoadSettings loadSettings = new SceneDefinitionLoadSettings())
    {
#if UNITY_EDITOR
        if (Application.isPlaying == false)
        {
            LoadDefinitionSimple(sceneDefinition);
            return null;
        }
#endif
        var processor = new LoadProcessor();
        processor.LoadDefinition(sceneDefinition, loadSettings);
        return processor;
    }

    public static Scene[] GetLoadedScenes()
    {
        var loadedScenesCount = SceneManager.loadedSceneCount;
        var loadedScenes = new Scene[loadedScenesCount];
        for (int i = 0; i < loadedScenesCount; i++)
        {
            loadedScenes[i] = SceneManager.GetSceneAt(i);
        }

        return loadedScenes;
    }

    public static bool IsSceneLoaded(SerializedScene scene)
    {
        var loadedScenes = GetLoadedScenes();
        foreach (var loadedScene in loadedScenes)
        {
            if (loadedScene.buildIndex == scene.BuildIndex)
            {
                return true;
            }
        }

        return false;
    }

    private static void LoadDefinitionSimple(SceneDefinition sceneDefinition)
    {
        var dependentScenes = sceneDefinition.GetLoadableDependentScenes();
        for (int i = 0; i < dependentScenes.Count; i++)
        {
            var scene = dependentScenes[i];
            if (i == 0)
            {
                LoadSceneAsync(scene, LoadSceneMode.Single);
            }
            else
            {
                LoadSceneAsync(scene, LoadSceneMode.Additive);
            }
        }

        var mainScene = sceneDefinition.mainScene;
        LoadSceneAsync(mainScene, LoadSceneMode.Additive);
    }

    [Conditional("UNITY_EDITOR")]
    private static void OpenSceneInEditor(SerializedScene scene, LoadSceneMode loadSceneMode)
    {
        var openSceneMode = loadSceneMode == LoadSceneMode.Additive
            ? OpenSceneMode.Additive
            : OpenSceneMode.Single;
        var loadedScene = EditorSceneManager.OpenScene(scene.ScenePath, openSceneMode);
        SceneManager.SetActiveScene(loadedScene);
    }
}
