using FPS.Core.Prefabs;
using System.Collections.Generic;

public interface IPrefabsProvider
{
    IReadOnlyCollection<PrefabData> GetPrefabs();
}
