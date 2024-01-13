using FPS.Common;

namespace FPS.Core.Interaction
{
    public interface IInteractionProcessor : IInitializable, IDeinitializable
    {
        void Process(Interactable interactable);
    }
}