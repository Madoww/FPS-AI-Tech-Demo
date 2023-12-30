using FPS.Core.Cutscenes;
using FPS.Core.Cutscenes.Data;
using FPS.Core.Cutscenes.Providers;
using UnityEngine;

namespace FPS.Game.Cutscenes.Nodes
{
    public class AnimationNode : CutsceneNode<AnimationNodeData>
    {
        private Animator animator;

        public override void Setup(IDataProvidersHandler providersHandler)
        {
            base.Setup(providersHandler);
            if (!providersHandler.TryGetProvider<AnimatorProvider>(out var animatorProvider))
            {
                Debug.LogWarning($"{nameof(AnimatorProvider)} not found.");
                return;
            }

            animator = animatorProvider.Animator;
        }

        public override void Execute()
        {
            AnimationClip clip = Data.animationClip;
            if (clip == null)
            {
                return;
            }

            animator?.Play(clip.name);
        }
    }
}
