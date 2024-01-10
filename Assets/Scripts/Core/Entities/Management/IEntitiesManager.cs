namespace FPS.Entities.Management
{
    public interface IEntitiesManager
    {
        void AppendEntity(GameEntity entity);
        void RemoveEntity(GameEntity entity);
        void RemoveEntity(string guid);
        GameEntity GetEntity(string guid);
    }
}