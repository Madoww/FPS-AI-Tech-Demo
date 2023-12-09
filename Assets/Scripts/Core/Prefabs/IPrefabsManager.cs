namespace FPS.Core.Prefabs
{
    public interface IPrefabsManager
    {
        bool TryGetPrefab<T>(string guid, out T prefab);
    }
}