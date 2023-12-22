using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace FPS.Editor.CutscenesOldOld
{
    internal abstract class CutsceneGraphElement<T> where T : GraphElement
    {
        protected CutsceneGraphElement(T element)
        {
            Element = element;
        }

        public virtual void Initialize()
        {
            Element.pickingMode = PickingMode.Ignore;
            Element.capabilities = 0;
            Element.focusable = false;
        }

        public T Element { get; }
    }
}