using UnityEngine;
using Zenject;
internal class EnemyFactory
{
    DiContainer diContainer;

    public EnemyFactory(DiContainer _diContainer) => diContainer = _diContainer;

    public Enemy Create (Enemy enemy, Vector3 position)
    {
        var enemyModel = diContainer.InstantiatePrefabForComponent<Enemy>
            (enemy, position, enemy.transform.rotation, null);
        return enemyModel;
    }
}
