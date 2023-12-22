using System.Collections.Generic;

namespace FPS.CutscenesOldOld
{
    public interface ICutscenesOldOldHolder
    {
        IReadOnlyList<CutsceneDefinition> Cutscenes { get; }

        void AppendCutscene(CutsceneDefinition cutscene);
        bool RemoveCutscene(CutsceneDefinition cutscene);
        bool HasCutscene(CutsceneDefinition cutscene);
    }
}