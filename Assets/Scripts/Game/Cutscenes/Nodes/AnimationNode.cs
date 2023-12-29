using FPS.Core.Cutscenes;
using FPS.Core.Cutscenes.Data;
using UnityEngine;

namespace FPS.Game.Cutscenes.Nodes
{
    public class AnimationNode : CutsceneNode<AnimationNodeData>
    {
        private Animator animator;

        public override void Setup(IDataProvidersHandler providersHandler)
        {
            base.Setup(providersHandler);
            var animatorProvider = providersHandler.TryGetProvider<AnimatorProvider>();
            if (animatorProvider == null)
            {
                Debug.LogWarning($"{nameof(Animator)} not provided.");
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
