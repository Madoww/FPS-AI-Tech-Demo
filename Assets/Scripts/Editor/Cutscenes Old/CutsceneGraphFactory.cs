using FPS.CutscenesOldOld;
using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace FPS.Editor.CutscenesOldOld
{
    internal class CutsceneGraphFactory
    {
        private List<CutsceneNode> CreateNodes(GraphView graphView, CutsceneDefinition cutscene)
        {
            var definitionNodes = cutscene.nodes;
            var cutsceneNodes = new List<CutsceneNode>();
            foreach (var definitionNode in definitionNodes)
            {
                var node = new CutsceneNode(new NodeElement() { name = "Node" }, definitionNode);
                node.Initialize();
                cutsceneNodes.Add(node);
                graphView.AddElement(node.Element);
            }

            return cutsceneNodes;
        }

        private List<CutsceneEdge> CreateEdges(GraphView graphView, List<CutsceneNode> nodes)
        {
            var edges = CreateConnections(nodes);
            foreach (var edge in edges)
            {
                graphView.AddElement(edge.Element);
            }

            return edges;
        }

        private List<CutsceneEdge> CreateConnections(List<CutsceneNode> nodes)
        {
            var edges = new List<CutsceneEdge>();
            foreach (var node in nodes)
            {
                var destinations = nodes.FindAll((otherNode) => otherNode.NodeDefinition.Equals(node.NodeDefinition.nextNode));
                edges.AddRange(CreateConnections(destinations, node));
            }

            return edges;
        }

        private List<CutsceneEdge> CreateConnections(List<CutsceneNode> nodes, CutsceneNode sourceNode)
        {
            var edges = new List<CutsceneEdge>();
            foreach (var node in nodes)
            {
                var input = node.Input;
                var output = sourceNode.Output;
                var edge = new CutsceneEdge(output.ConnectTo(input));
                edge.Initialize();
                edges.Add(edge);
            }

            return edges;
        }

        private void PositionNodes(List<CutsceneNode> nodes, in GraphSettings graphSettings)
        {
            if (nodes == null || nodes.Count == 0)
            {
                return;
            }

            var visitedNodes = new HashSet<CutsceneNode>();
            var column = 0;
            var destinations = new List<Type>()
            {
                //nodes[0].FlowType
            };

            foreach (var node in nodes)
            {
                SetColumn(column, node, in graphSettings);
                column++;
            }
        }

        private List<Type> SetColumn(int c, CutsceneNode node, in GraphSettings graphSettings)
        {
            return SetColumn(c, new List<CutsceneNode> { node }, in graphSettings);
        }

        private List<Type> SetColumn(int c, List<CutsceneNode> nodes, in GraphSettings graphSettings)
        {
            var destinations = new List<Type>();
            for (var i = 0; i < nodes.Count; i++)
            {
                var node = nodes[i];
                var x = c * graphSettings.xNodeOffset;
                var y = i * graphSettings.yNodeOffset;
                node.Element.SetPosition(new Rect(x, y, 0, 0));
                //destinations.AddRange(node.State.GetDestinations());
            }

            return destinations;
        }

        private void CollapseNodes(IReadOnlyList<CutsceneNode> nodes)
        {
            foreach (var node in nodes)
            {
                node.Element.expanded = false;
            }
        }

        public StateMachineGraphView CreateGraph(CutsceneDefinition cutscene, in GraphSettings graphSettings)
        {
            var graphView = CreateEmptyGraph();
            return CreateGraph(cutscene, in graphSettings, graphView);
        }

        public StateMachineGraphView CreateGraph(CutsceneDefinition cutscene, in GraphSettings graphSettings, StateMachineGraphView graphView)
        {
            var prevElements = graphView.graphElements;
            graphView.DeleteElements(prevElements.ToList());

            var nodes = CreateNodes(graphView, cutscene);
            var edges = CreateEdges(graphView, nodes);
            PositionNodes(nodes, in graphSettings);
            CollapseNodes(nodes);
            return graphView;
        }

        public static StateMachineGraphView CreateEmptyGraph()
        {
            var graphView = new StateMachineGraphView()
            {
                name = "Graph",
            };
            graphView.SetupZoom(0.05f, ContentZoomer.DefaultMaxScale);
            graphView.AddManipulator(new ContentDragger());
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