namespace FPS.Core.Cutscenes.Management
{
    public interface ICutscenesManager
    {
        void RegisterCutscene(CutsceneDefinition definition, ICutsceneFactory factory);
        Cutscene LoadCutscene(CutsceneDefinition definition);
    }
}