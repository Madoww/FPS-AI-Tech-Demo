using FPS.AI.Behaviour;
using FPS.Editor.GraphEditor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace FPS.Editor.BehaviourTree
{
    public class BehaviourTreeEditorWindow : EditorWindow
    {
        private readonly InspectorView nodeInspectorView = new InspectorView();

        private BehaviourTreeDefinition behaviourTree;
        private BehaviourTreeGraphViewPanel graphView;

        [MenuItem("Tools/Behaviour Tree Editor", false)]
        public static void Init()
        {
            GetWindow(typeof(BehaviourTreeEditorWindow), false, "Behaviour Tree");
        }

        private void CreateGUI()
        {
            rootVisualElement.Clear();
            var splitView = new TwoPaneSplitView(0, 300.0f, TwoPaneSplitViewOrientation.Horizontal);
            rootVisualElement.Add(splitView);

            var leftPane = new VisualElement();
            splitView.Add(leftPane);
            var rightPane = new VisualElement();
            splitView.Add(rightPane);

            leftPane.Add(new IMGUIContainer(() =>
            {
                using (new EditorGUILayout.VerticalScope(Style.pickerSectionStyle))
                {
                    EditorGUI.BeginChangeCheck();
                    behaviourTree = EditorGUILayout.ObjectField(behaviourTree, typeof(BehaviourTreeDefinition), false) as BehaviourTreeDefinition;
                    if (behaviourTree == null)
                    {
                        return;
                    }

                    var displayName = new GUIContent(behaviourTree.name);
                    Rect position = GUILayoutUtility.GetRect(GUIContent.none, Style.pickerSectionStyle);

                    EditorGUILayout.Space();

                    if (EditorGUI.EndChangeCheck())
                    {
                        CreateGUI();
                    }

                    if (GUILayout.Button(Style.refreshButtonContent, Style.refreshButtonStyle))
                    {
                        CreateGUI();
                    }

                    nodeInspectorView.DrawGui();
                }
            }));

            UpdateGraph();
            rightPane.Add(graphView);
        }

        private void UpdateGraph()
        {
            if (graphView == null)
            {
                graphView = GraphViewUtility.CreateGraphView<BehaviourTreeGraphViewPanel>(behaviourTree);
                graphView.OnNodeSelected += OnSelectNode;
                return;
            }

            graphView = GraphViewUtility.CreateGraphView(behaviourTree, graphView);
        }

        private void OnSelectNode(GraphNodeView node)
        {
            nodeInspectorView.UpdateSelection(node);
        }

        private static class Style
        {
            internal static readonly GUIStyle pickerSectionStyle = new GUIStyle(EditorStyles.inspectorFullWidthMargins);
            internal static readonly GUIStyle refreshButtonStyle = new GUIStyle(EditorStyles.miniButton);
            internal static readonly GUIContent refreshButtonContent = EditorGUIUtility.IconContent("refresh");
        }
    }
}