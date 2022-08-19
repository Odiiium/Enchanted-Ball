using UnityEngine;

internal class ObstacleFactory
{
    public Obstacle Create(Obstacle obstacle, Vector3 position)
    {
        var obstacleModel= GameObject.Instantiate(obstacle, position, obstacle.transform.rotation, null);
        return obstacleModel;
    }
}
