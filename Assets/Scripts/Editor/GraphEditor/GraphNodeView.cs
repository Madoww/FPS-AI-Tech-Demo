using FPS.Common;
using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace FPS.Editor.GraphEditor
{
    public class GraphNodeView : Node
    {
        public event Action<GraphNodeView> OnNodeSelected;

        private Port input;
        private Port output;
        private ScriptableNode nodeDefinition;
        private NodePositionsHolder nodePositionsHolder;

        public Port Input => input;
        public Port Output => output;
        public ScriptableNode NodeDefinition => nodeDefinition;

        public GraphNodeView(ScriptableNode nodeDefinition, NodePositionsHolder nodePositionsHolder)
        {
            this.nodeDefinition = nodeDefinition;
            this.title = nodeDefinition.displayName;
            this.viewDataKey = nodeDefinition.guid;
            this.nodePositionsHolder = nodePositionsHolder;
            var position = nodePositionsHolder.GetPosition(nodeDefinition);
            style.left = position.x;
            style.top = position.y;
            CreateInputPorts();
            CreateOutputPorts();
        }

        public override void SetPosition(Rect newPosition)
        {
            base.SetPosition(newPosition);
            var position = new Vector2(newPosition.xMin, newPosition.yMin);
            nodePositionsHolder.StorePosition(nodeDefinition, position);
        }

        public override void OnSelected()
        {
            base.OnSelected();
            OnNodeSelected?.Invoke(this);
        }

        private void CreateInputPorts()
        {
            input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, null);
            //var inputField = new TextField("Description", int.MaxValue, true, false, '*');
            //extensionContainer.Add(inputField);
            inputContainer.Add(input);
        }

        private void CreateOutputPorts()
        {
            output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, null);
            outputContainer.Add(output);
        }
    }
}