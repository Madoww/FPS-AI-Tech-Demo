using System;

namespace FPS.Core.Cutscenes
{
    public interface ICutsceneNode
    {
        Type DataType { get; }

        void Execute();
        void Setup(CutsceneNodeData data);
    }
}