using FPS.Cutscenes;
using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace FPS.Editor.Cutscenes
{
    public class CutsceneNodeView : Node
    {
        public event Action<CutsceneNodeView> OnNodeSelected;

        private Port input;
        private Port output;
        private CutsceneNodeDefinition nodeDefinition;

        public Port Input => input;
        public Port Output => output;
        public CutsceneNodeDefinition NodeDefinition => nodeDefinition;

        public CutsceneNodeView(CutsceneNodeDefinition nodeDefinition)
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