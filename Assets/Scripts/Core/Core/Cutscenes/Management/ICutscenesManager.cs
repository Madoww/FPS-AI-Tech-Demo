namespace FPS.Core.Cutscenes.Management
{
    public interface ICutscenesManager
    {
        Cutscene LoadCutscene(CutsceneDefinition definition);
    }
}