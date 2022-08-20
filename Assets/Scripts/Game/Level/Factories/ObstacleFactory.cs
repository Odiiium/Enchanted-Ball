using UnityEngine;
using Zenject;
internal class ObstacleFactory
{
    DiContainer diContainer;

    public ObstacleFactory(DiContainer _diContainer) => diContainer = _diContainer;
    public Obstacle Create(Obstacle obstacle, Vector3 position)
    {
        var obstacleModel= diContainer.InstantiatePrefabForComponent<Obstacle>
            (obstacle, position, obstacle.transform.rotation, null);
        return obstacleModel;
    }
}
