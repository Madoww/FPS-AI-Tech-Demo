using UnityEngine;

namespace FPS.Core.Cutscenes.Providers
{
    public class AnimatorProvider : ICutsceneDataProvider
    {
        [SerializeField]
        private Animator animator;

        public Animator Animator => animator;
    }
}