using DG.Tweening;
using FPS.UI.Animation;
using System;
using UnityEngine;

namespace FPS.UI.Misc
{
    public class StandardAnimationActivityHandler : IActivityHandler
    {
        [SerializeReference, ReferencePicker]
        private IAnimationContext animationContext;

        private Sequence sequence;

        public bool Shows { get; private set; }
        public bool Hides { get; private set; }

        public void Show(IActivityTarget target)
        {
            Show(target, false);
        }

        public void Show(IActivityTarget target, bool immediately, Action onFinish = null)
        {
            target.SetActive(true);
            var sequence = GetAnimationSequence();
            if (sequence == null || sequence.IsComplete())
            {
                onFinish?.Invoke();
                return;
            }

            sequence.OnComplete(() =>
            {
                OnAnimationFinish();
                onFinish?.Invoke();
            });

            StartShowAnimation(sequence);
            if (immediately)
            {
                sequence.Complete();
            }
        }

        public void Hide(IActivityTarget target)
        {
            Hide(target, false);
        }

        public void Hide(IActivityTarget target, bool immediately, Action onFinish = null)
        {
            var sequence = GetAnimationSequence();
            if (sequence == null)
            {
                return;
            }

            sequence.OnRewind(() =>
            {
                OnFinishedPlaying();
            });
            StartHideAnimation(sequence);
            if (immediately)
            {
                sequence.Goto(0);
                OnFinishedPlaying();
            }

            void OnFinishedPlaying()
            {
                OnAnimationFinish();
                target.SetActive(false);
                onFinish?.Invoke();
            }
        }

        public void Dispose()
        {
            sequence?.Kill();
            sequence = null;
        }

        private void StartShowAnimation(Sequence sequence)
        {
            if (sequence == null)
            {
                return;
            }

            sequence.PlayForward();
            Shows = true;
            Hides = false;
        }

        private void StartHideAnimation(Sequence sequence)
        {
            if (sequence == null)
            {
                return;
            }

            sequence.PlayBackwards();
            Shows = false;
            Hides = true;
        }

        private void OnAnimationFinish()
        {
            Shows = false;
            Hides = false;
        }

        private Sequence GetAnimationSequence()
        {
            if (sequence == null)
            {
                sequence = animationContext?.GetSequence(true);
                sequence.Pause();
                sequence.SetAutoKill(false);
            }

            return sequence;
        }
    }
}