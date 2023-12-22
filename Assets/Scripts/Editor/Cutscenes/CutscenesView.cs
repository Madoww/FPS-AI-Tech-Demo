using FPS.Cutscenes;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace FPS.Editor.Cutscenes
{
    public class CutscenesView : GraphView
    {
        public event Action<CutsceneNodeView> OnNodeSelected;

        private CutsceneDefinition currentDefinition;

        public new class UxmlFactory : UxmlFactory<CutscenesView, GraphView.UxmlTraits>
        { }

        public CutscenesView()
        {
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Scripts/Editor/Cutscenes/CutscenesEditor.uss");
            styleSheets.Add(styleSheet);
            this.AddManipulator(new ContentZoomer());
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());
            Insert(0, new GridBackground());
        }

        public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
        {
            evt.menu.AppendAction("Add Node", (action) => CreateNodeDefinition());
        }

        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            return ports.ToList().Where(endPort => endPort.direction != startPort.direction
            && endPort.node != startPort.node).ToList();
        }

        public void PopulateView(CutsceneDefinition definition)
        {
            currentDefinition = definition;
            graphViewChanged -= OnGraphViewChanged;
            DeleteElements(graphElements);
            graphViewChanged += OnGraphViewChanged;
            CreateNodeViews(definition);
            CreateEdges(definition);
        }

        private GraphViewChange OnGraphViewChanged(GraphViewChange graphViewChange)
        {
            var elementsToRemove = graphViewChange.elementsToRemove;
            if (elementsToRemove != null)
            {
                foreach (var element in elementsToRemove)
                {
                    CutsceneNodeView nodeView = element as CutsceneNodeView;
                    if (nodeView != null)
                    {
                        CutsceneNodeDefinition nodeDefinition = nodeView.NodeDefinition;
                        currentDefinition.RemoveNode(nodeDefinition);
                        continue;
                    }

                    Edge edge = element as Edge;
                    if (edge != null)
                    {
                        CutsceneNodeView parentView = edge.output.node as CutsceneNodeView;
                        CutsceneNodeView childView = edge.input.node as CutsceneNodeView;
                        CutsceneNodeDefinition parentNodeDefinition = parentView.NodeDefinition;
                        CutsceneNodeDefinition childNodeDefinition = childView.NodeDefinition;
                        parentNodeDefinition.RemoveChild(childNodeDefinition);
                    }


                }
            }

            var edgesToCreate = graphViewChange.edgesToCreate;
            if (edgesToCreate != null)
            {
                foreach (var edge in edgesToCreate)
                {
                    CutsceneNodeView parentView = edge.output.node as CutsceneNodeView;
                    CutsceneNodeView childView = edge.input.node as CutsceneNodeView;
                    CutsceneNodeDefinition parentNodeDefinition = parentView.NodeDefinition;
                    CutsceneNodeDefinition childNodeDefinition = childView.NodeDefinition;
                    parentNodeDefinition.AddChild(childNodeDefinition);
                }
            }

            return graphViewChange;
        }

        private void CreateNodeViews(CutsceneDefinition definition)
        {
            foreach (CutsceneNodeDefinition nodeDefinition in definition.nodes)
            {
                CreateNodeView(nodeDefinition);
            }
        }

        private void CreateNodeView(CutsceneNodeDefinition node)
        {
            CutsceneNodeView nodeView = new CutsceneNodeView(node);
            nodeView.OnNodeSelected += OnNodeSelected;
            AddElement(nodeView);
        }

        private void CreateEdges(CutsceneDefinition definition)
        {
            foreach (CutsceneNodeDefinition node in definition.nodes)
            {
                CreateEdges(node);
            }
        }

        private void CreateEdges(CutsceneNodeDefinition node)
        {
            CutsceneNodeView parentView = GetNodeView(node);
            foreach (CutsceneNodeDefinition child in node.childNodes)
            {
                CutsceneNodeView childView = GetNodeView(child);
                Edge edge = parentView.Output.ConnectTo(childView.Input);
                AddElement(edge);
            }
        }

        private void CreateNodeDefinition()
        {
            var node = currentDefinition.AppendNode<CutsceneNodeDefinition>();
            CreateNodeView(node);
        }

        private CutsceneNodeView GetNodeView(CutsceneNodeDefinition node)
        {
            return GetNodeByGuid(node.guid) as CutsceneNodeView;
        }
    }
}