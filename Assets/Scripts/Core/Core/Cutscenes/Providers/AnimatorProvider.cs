using UnityEngine;

namespace FPS.Core.Cutscenes.Providers
{
    public class AnimatorProvider : CutsceneDataProvider
    {
        [SerializeField]
        private Animator animator;

        public Animator Animator => animator;
    }
}