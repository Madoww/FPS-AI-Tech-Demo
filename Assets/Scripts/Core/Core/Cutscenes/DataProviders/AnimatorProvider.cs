using FPS.Core.Cutscenes;
using UnityEngine;

public class AnimatorProvider : ICutsceneDataProvider
{
    [SerializeField]
    private Animator animator;

    public Animator Animator => animator;
}
