namespace FPS.Core.Cutscenes
{
    public interface ICutscenesManager
    {
        Cutscene LoadCutscene(CutsceneDefinition definition);
    }
}