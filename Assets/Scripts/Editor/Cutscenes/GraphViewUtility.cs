using FPS.Cutscenes;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace FPS.Editor.Cutscenes
{
    public static class GraphViewUtility
    {
        public static CutscenesView CreateGraphView(CutsceneDefinition cutsceneDefinition)
        {
            var graphView = CreateGraphView();
            graphView = CreateGraphView(cutsceneDefinition, graphView);
            return graphView;
        }

        public static CutscenesView CreateGraphView(CutsceneDefinition cutsceneDefinition, CutscenesView graphView)
        {
            if (graphView == null)
            {
                graphView = CreateGraphView();
            }

            graphView.PopulateView(cutsceneDefinition);
            return graphView;
        }

        public static CutscenesView CreateGraphView()
        {
            var graphView = new CutscenesView()
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