namespace FPS.Prefabs
{
    public interface IPrefabsManager
    {
        bool TryGetPrefab<T>(string guid, out T prefab);
    }
}