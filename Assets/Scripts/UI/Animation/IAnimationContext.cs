using DG.Tweening;

namespace FPS.UI.Animation
{
    public interface IAnimationContext
    {
        Sequence GetSequence(bool fromSequence);
        Sequence GetSequence(Sequence sequence, bool fromSequence);
    }
}