using System;
using System.Collections.Generic;

namespace FPS.Core.Cutscenes
{
    public interface ICutsceneNode
    {
        Type DataType { get; }

        void Execute();
        void Setup(IDataProvidersHandler providersHandler);
        void Setup(CutsceneNodeData data);
        void AddChild(ICutsceneNode child);
        void AddChildren(IList<ICutsceneNode> children);
    }
}