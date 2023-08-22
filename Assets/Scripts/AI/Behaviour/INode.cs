using System.Collections.Generic;

namespace FPS.AI.Behaviour
{
    public interface INode
    {
        NodeState Evaluate(Dictionary<string, object> data);
    }
}