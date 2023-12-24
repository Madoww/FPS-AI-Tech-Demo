using FPS.Common;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using FPS.Editor.GraphEditor;

namespace FPS.Editor.GraphEditor
{
    public static class GraphViewUtility
    {
        public static GraphViewPanel CreateGraphView(ScriptableNodesHolder cutsceneDefinition)
        {
            var graphView = CreateGraphView();
            graphView = CreateGraphView(cutsceneDefinition, graphView);
            return graphView;
        }

        public static GraphViewPanel CreateGraphView(ScriptableNodesHolder cutsceneDefinition, GraphViewPanel graphView)
        {
            if (graphView == null)
            {
                graphView = CreateGraphView();
            }

            graphView.PopulateView(cutsceneDefinition);
            return graphView;
        }

        public static GraphViewPanel CreateGraphView()
        {
            var graphView = new GraphViewPanel()
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