using FPS.Core.Cutscenes;
using FPS.Core.Cutscenes.Data;
using UnityEngine;

namespace FPS.Game.Cutscenes.Nodes
{
    public class PrintMessageNode : CutsceneNode<PrintMessageNodeData>
    {
        public PrintMessageNode(PrintMessageNodeData data) : base(data)
        { }

        public override void Execute()
        {
            Debug.Log(Data.message);
        }
    }
}