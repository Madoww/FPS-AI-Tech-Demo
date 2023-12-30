namespace FPS.Core.Cutscenes.Management
{
    public interface ICutscenesController
    {
        bool IsPlaying { get; }

        void Play(CutsceneDefinition cutscene);
    }
}