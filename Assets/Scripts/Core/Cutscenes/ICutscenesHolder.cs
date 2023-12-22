using System.Collections.Generic;

namespace FPS.Cutscenes
{
    public interface ICutscenesHolder
    {
        IReadOnlyList<CutsceneDefinition> Cutscenes { get; }

        void AppendCutscene(CutsceneDefinition cutscene);
        bool RemoveCutscene(CutsceneDefinition cutscene);
        bool HasCutscene(CutsceneDefinition cutscene);
    }
}