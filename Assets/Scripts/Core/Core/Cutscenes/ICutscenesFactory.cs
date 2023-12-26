namespace FPS.Core.Cutscenes
{
    public interface ICutscenesFactory
    {
        Cutscene CreateCutscene(CutsceneDefinition cutsceneDefinition);
    }
}