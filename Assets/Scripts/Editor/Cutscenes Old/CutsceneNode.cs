using FPS.CutscenesOldOld;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace FPS.Editor.CutscenesOldOld
{
    internal class CutsceneNode : CutsceneGraphElement<NodeElement>
    {
        private const string activeNodeHexColor = "#875216";
        private const string activeNodeTextInfo = "A";

        private readonly CutsceneNodeDefinition nodeDefinition;

        public CutsceneNodeDefinition NodeDefinition => nodeDefinition;

        public CutsceneNode(NodeElement element, CutsceneNodeDefinition cutsceneNodeDefinition) : base(element)
        {
            nodeDefinition = cutsceneNodeDefinition;
        }

        private void CreatePorts()
        {
            Input = Element.InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, null);
            Output = Element.InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, null);
            Element.inputContainer.Add(Input);
            Element.outputContainer.Add(Output);
        }

        public override void Initialize()
        {
            base.Initialize();

            CreatePorts();

            //if (stateMachine.IsStateActive(State))
            {
                ColorUtility.TryParseHtmlString(activeNodeHexColor, out var color);
                var activeLabel = new Label(activeNodeTextInfo);
                activeLabel.style.unityFontStyleAndWeight = new StyleEnum<FontStyle>(FontStyle.Bold);
                Element.titleContainer.Add(activeLabel);
                Element.titleContainer.style.backgroundColor = color;
                Element.style.borderLeftColor = color;
            }

            var name = nodeDefinition.displayName;
            Element.title = ObjectNames.NicifyVariableName(name);
            Element.expanded = true;
            Element.Add(new Button(() =>
            {

            })
            {
                text = "Save"
            });
            Element.Initialize();
        }

        //public BaseState State { get; }
        public Port Input { get; private set; }
        public Port Output { get; private set; }
    }
}