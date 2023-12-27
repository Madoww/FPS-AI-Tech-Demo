using FPS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;

namespace FPS.Editor.GraphEditor
{
    //TODO: Generic typed graph nodes.
    public class GraphViewPanel : GraphView
    {
        public event Action<GraphNodeView> OnNodeSelected;

        private ScriptableNodesHolder nodesHolder;

        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            return ports.ToList().Where(endPort => endPort.direction != startPort.direction
            && endPort.node != startPort.node).ToList();
        }

        public void PopulateView(ScriptableNodesHolder holder)
        {
            nodesHolder = holder;
            graphViewChanged -= OnGraphViewChanged;
            DeleteElements(graphElements);
            graphViewChanged += OnGraphViewChanged;
            CreateNodeViews(holder);
            CreateEdges(holder);
        }

        protected void CreateNodeDefinition(Type type)
        {
            var node = nodesHolder.AppendNode(type);
            if (node == null)
            {
                return;
            }

            CreateNodeView(node);
        }

        private GraphViewChange OnGraphViewChanged(GraphViewChange graphViewChange)
        {
            var elementsToRemove = graphViewChange.elementsToRemove;
            if (elementsToRemove != null)
            {
                foreach (var element in elementsToRemove)
                {
                    GraphNodeView nodeView = element as GraphNodeView;
                    if (nodeView != null)
                    {
                        ScriptableNode nodeDefinition = nodeView.NodeDefinition;
                        nodesHolder.RemoveNode(nodeDefinition);
                        continue;
                    }

                    Edge edge = element as Edge;
                    if (edge != null)
                    {
                        GraphNodeView parentView = edge.output.node as GraphNodeView;
                        GraphNodeView childView = edge.input.node as GraphNodeView;
                        ScriptableNode parentNodeDefinition = parentView.NodeDefinition;
                        ScriptableNode childNodeDefinition = childView.NodeDefinition;
                        parentNodeDefinition.RemoveChild(childNodeDefinition);
                    }


                }
            }

            var edgesToCreate = graphViewChange.edgesToCreate;
            if (edgesToCreate != null)
            {
                foreach (var edge in edgesToCreate)
                {
                    GraphNodeView parentView = edge.output.node as GraphNodeView;
                    GraphNodeView childView = edge.input.node as GraphNodeView;
                    ScriptableNode parentNodeDefinition = parentView.NodeDefinition;
                    ScriptableNode childNodeDefinition = childView.NodeDefinition;
                    parentNodeDefinition.AddChild(childNodeDefinition);
                }
            }

            return graphViewChange;
        }

        private void CreateNodeViews(ScriptableNodesHolder definition)
        {
            foreach (ScriptableNode nodeDefinition in definition.nodes)
            {
                CreateNodeView(nodeDefinition);
            }
        }

        private void CreateNodeView(ScriptableNode node)
        {
            GraphNodeView nodeView = new GraphNodeView(node);
            nodeView.OnNodeSelected += OnNodeSelected;
            AddElement(nodeView);
        }

        private void CreateEdges(ScriptableNodesHolder definition)
        {
            foreach (ScriptableNode node in definition.nodes)
            {
                CreateEdges(node);
            }
        }

        private void CreateEdges(ScriptableNode node)
        {
            GraphNodeView parentView = GetNodeView(node);
            foreach (ScriptableNode child in node.childNodes)
            {
                GraphNodeView childView = GetNodeView(child);
                Edge edge = parentView.Output.ConnectTo(childView.Input);
                AddElement(edge);
            }
        }

        private GraphNodeView GetNodeView(ScriptableNode node)
        {
            return GetNodeByGuid(node.guid) as GraphNodeView;
        }
    }
}