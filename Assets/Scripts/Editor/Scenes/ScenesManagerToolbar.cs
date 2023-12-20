using Toolbox.Editor;
using UnityEditor;
using UnityEngine;

namespace FPS.Editor.Scenes
{
    using FPS.Common;
    using FPS.Game.Scenes;

    [InitializeOnLoad]
    public static class ScenesManagerToolbar
    {
        private static IScenesHolder scenesHolder;
        private static SceneDefinitionPicker picker;

        static ScenesManagerToolbar()
        {
            scenesHolder = AssetUtility.GetFirstAsset<ScenesHolder>();
            if (scenesHolder == null)
            {
                Debug.LogError($"{nameof(ScenesHolder)} not found.");
                return;
            }

            picker = new SceneDefinitionPicker();
            picker.Initialize(scenesHolder);

            ToolboxEditorToolbar.OnToolbarGui += () =>
            {
                picker.OnGui();
            };
        }
    }
}