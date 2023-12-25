using FPS.Common;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace FPS.Editor.GraphEditor
{
    public static class GraphViewUtility
    {
        public static T CreateGraphView<T>(ScriptableNodesHolder cutsceneDefinition) where T : GraphViewPanel, new()
        {
            T graphView = CreateGraphView<T>();
            graphView = CreateGraphView<T>(cutsceneDefinition, graphView);
            return graphView;
        }

        public static T CreateGraphView<T>(ScriptableNodesHolder cutsceneDefinition, T graphView) where T : GraphViewPanel, new()
        {
            if (graphView == null)
            {
                graphView = CreateGraphView<T>();
            }

            graphView.PopulateView(cutsceneDefinition);
            return graphView;
        }

        public static T CreateGraphView<T>() where T : GraphViewPanel, new()
        {
            var graphView = new T()
            {
                name = "Graph",
            };
            graphView.SetupZoom(0.05f, ContentZoomer.DefaultMaxScale);
            graphView.AddManipulator(new ContentDragger());
            graphView.AddManipulator(new SelectionDragger());
            graphView.AddManipulator(new RectangleSelector());
            graphView.StretchToParentSize();

            var gridBackground = new GridBackground()
            {
                name = "Grid"
            };

            graphView.Add(gridBackground);
            gridBackground.SendToBack();
            return graphView;
        }
    }
}