using System;
using System.Collections;
using System.Collections.Generic;
using FPS.Cutscenes;
using FPS.Common;
using FPS.Editor.Cutscenes;
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
            inputContainer.Add(input);
        }

        private void CreateOutputPorts()
        {
            output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, null);
            outputContainer.Add(output);
        }
    }
}