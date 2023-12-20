using FPS.Game.Scenes;
using Toolbox.Editor;
using UnityEngine;

namespace FPS.Editor.Scenes
{
    public class SceneDefinitionPicker
    {
        private const string definitionNameFormat = "{0} ({1})";

        private IScenesHolder scenesHolder;
        private int selectedIndex;

        public void Initialize(IScenesHolder scenesHolder)
        {
            this.scenesHolder = scenesHolder;
        }

        public void OnGui()
        {
            var sceneDefinitionsNames = SceneDefinitionsNames;
            var sceneDefinitionsNamesLength = sceneDefinitionsNames.Length;
            if (sceneDefinitionsNamesLength == 0)
            {
                return;
            }

            if (selectedIndex > sceneDefinitionsNamesLength)
            {
                selectedIndex = sceneDefinitionsNamesLength;
            }

            var guiDisplayName = new GUIContent(sceneDefinitionsNames[selectedIndex]);
            ToolboxEditorGui.DrawSearchablePopup(new Rect(230, 0, 150, 30), guiDisplayName, selectedIndex, sceneDefinitionsNames,
                (int index) =>
                {
                    selectedIndex = index;
                    ScenesLoadingUtility.LoadDefinition(scenesHolder.SceneDefinitions[index]);
                });
        }

        private string[] SceneDefinitionsNames
        {
            get
            {
                var definitions = scenesHolder.SceneDefinitions;
                var sceneDefinitionsNames = new string[definitions.Count];
                for (var i = 0; i < definitions.Count; i++)
                {
                    var definition = definitions[i];
                    sceneDefinitionsNames[i] = string.Format(definitionNameFormat, definition.mainScene.SceneName, definition.displayName);
                }

                return sceneDefinitionsNames;
            }
        }
    }
}