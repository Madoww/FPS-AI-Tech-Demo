using Toolbox.Editor;
using UnityEditor;
using UnityEngine;

namespace FPS.Editor.Scenes
{
    using FPS.Common;
    using FPS.Game.Scenes;
    using Editor = UnityEditor.Editor;

    public class ScenesManagerWindow : EditorWindow
    {
        private bool showScenesInspector = true;
        private bool showDataMaintenance = true;
        private string searchString = string.Empty;
        private Editor scenesHolderEditor;
        private ScenesHolder scenesHolder;

        [MenuItem("Scenes/Scenes Manager Window")]
        public static void ShowWindow()
        {
            var window = GetWindow<ScenesManagerWindow>();
            window.titleContent = new GUIContent("Scenes Manager");
        }

        private void OnEnable()
        {
            scenesHolder = AssetUtility.GetFirstAsset<ScenesHolder>();
        }

        private void OnDisable()
        {
            DisposeEditor();
        }

        private void OnGUI()
        {
            if (scenesHolder == null)
            {
                EditorGUILayout.HelpBox($"{nameof(ScenesHolder)} not found in assets.", MessageType.Error);
                return;
            }

            PrepareEditor();
            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                showDataMaintenance = EditorGUILayout.Foldout(showDataMaintenance, "Data Maintenance", Style.foldout);
                if (showDataMaintenance)
                {
                    scenesHolderEditor.OnInspectorGUI();
                }
            }

            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                showScenesInspector = EditorGUILayout.Foldout(showScenesInspector, "Scenes Inspector", Style.foldout);
                if (showScenesInspector)
                {
                    DrawSearchField();
                    var formattedSearchString = searchString.ToLower();
                    var sceneDefinitions = scenesHolder.SceneDefinitions;
                    foreach (var sceneDefinition in sceneDefinitions)
                    {
                        if (sceneDefinition == null)
                        {
                            continue;
                        }

                        var formattedSceneDefinitionName = sceneDefinition.name.ToLower();
                        if (formattedSceneDefinitionName.Contains(formattedSearchString))
                        {
                            DrawSceneDefinition(sceneDefinition);
                        }
                    }
                }
            }
        }

        private void PrepareEditor()
        {
            if (scenesHolderEditor != null)
            {
                return;
            }

            scenesHolderEditor = Editor.CreateEditor(scenesHolder);
            scenesHolderEditor.hideFlags = HideFlags.HideAndDontSave;
            if (scenesHolderEditor is ToolboxEditor toolboxEditor)
            {
                toolboxEditor.IgnoreProperty("m_Script");
            }
        }

        private void DisposeEditor()
        {
            if (scenesHolderEditor == null)
            {
                return;
            }

            DestroyImmediate(scenesHolderEditor);
        }

        private void DrawSearchField()
        {
            GUILayout.BeginHorizontal(GUI.skin.FindStyle("Toolbar"));
            searchString = GUILayout.TextField(searchString, GUI.skin.FindStyle("ToolbarSearchTextField"));
            if (GUILayout.Button(string.Empty, GUI.skin.FindStyle("ToolbarSearchCancelButton")))
            {
                searchString = string.Empty;
                GUI.FocusControl(null);
            }

            GUILayout.EndHorizontal();
        }

        private void DrawSceneDefinition(SceneDefinition definition)
        {
            using (new EditorGUILayout.HorizontalScope(EditorStyles.helpBox))
            {
                using (new EditorGUILayout.VerticalScope(GUILayout.MaxWidth(300)))
                {
                    GUILayout.Label(definition.displayName, EditorStyles.boldLabel);
                    GUILayout.Label(definition.mainScene.SceneName);
                    if (GUILayout.Button("Select"))
                    {
                        EditorGUIUtility.PingObject(definition);
                    }

                    if (GUILayout.Button("Open"))
                    {
                        ScenesLoadingUtility.LoadDefinition(definition);
                    }

                    if (scenesHolder.HasDefinition(definition))
                    {
                        if (GUILayout.Button("Remove"))
                        {
                            scenesHolder.RemoveDefinition(definition);
                        }
                    }
                    else
                    {
                        if (GUILayout.Button("Add"))
                        {
                            scenesHolder.AppendDefinition(definition);
                        }
                    }
                }

                using (new EditorGUILayout.VerticalScope())
                {
                    GUILayout.Label("Description");
                    definition.description = EditorGUILayout.TextArea(definition.description, GUILayout.Height(80));
                }
            }
        }

        private static class Style
        {
            internal static readonly GUIStyle foldout = new GUIStyle(EditorStyles.foldout)
            {
                fontStyle = FontStyle.Bold
            };
        }
    }
}
