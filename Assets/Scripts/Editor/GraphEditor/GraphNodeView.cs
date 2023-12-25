using FPS.Common;
using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace FPS.Editor.GraphEditor
{
    public class GraphNodeView : Node
    {
        public event Action<GraphNodeView> OnNodeSelected;

        public string description;

        private Port input;
        private Port output;
        private ScriptableNode nodeDefinition;

        public Port Input => input;
        public Port Output => output;
        public ScriptableNode NodeDefinition => nodeDefinition;

        public GraphNodeView(ScriptableNode nodeDefinition)
        {
            this.nodeDefinition = nodeDefinition;
            this.title = nodeDefinition.displayName;
            this.viewDataKey = nodeDefinition.guid;
            style.left = nodeDefinition.position.x;
            style.top = nodeDefinition.position.y;
            CreateInputPorts();
            CreateOutputPorts();
        }

        public override void SetPosition(Rect newPos)
        {
            base.SetPosition(newPos);
            nodeDefinition.position.x = newPos.xMin;
            nodeDefinition.position.y = newPos.yMin;
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