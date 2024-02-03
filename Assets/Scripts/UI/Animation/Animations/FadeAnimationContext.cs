using DG.Tweening;
using UnityEngine;

namespace FPS.UI.Animation.Animations
{
    public class FadeAnimationContext : IAnimationContext
    {
        [SerializeField]
        private CanvasGroup canvasGroup;
        [SerializeField]
        private float duration;
        [SerializeField]
        private AnimationCurve curve;

        public Sequence GetSequence(bool fromSequence)
        {
            Sequence sequence = DOTween.Sequence();
            return GetSequence(sequence, fromSequence);
        }

        public Sequence GetSequence(Sequence sequence, bool fromSequence)
        {
            sequence.Append(CreateTween(fromSequence));
            return sequence;
        }

        private Tween CreateTween(bool fromSequence)
        {
            var tween = canvasGroup.DOFade(1, duration)
                .SetEase(curve);
            if (fromSequence)
            {
                tween.From(0);
            }

            return tween;
        }
    }
}