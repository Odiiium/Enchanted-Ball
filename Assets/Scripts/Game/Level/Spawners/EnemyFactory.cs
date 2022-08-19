using UnityEngine;

internal class EnemyFactory
{
    public Enemy Create (Enemy enemy, Vector3 position)
    {
        var enemyModel = GameObject.Instantiate(enemy, position, enemy.transform.rotation, null);
        return enemyModel;
    }
}
