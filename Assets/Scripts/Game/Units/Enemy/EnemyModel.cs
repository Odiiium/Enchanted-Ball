using UnityEngine;
internal class EnemyModel : MonoBehaviour 
{
    internal EnemyMovable EnemyMovable { get => enemyMovable ??= new EnemyMovable();}
    EnemyMovable enemyMovable;
    internal Collider Collider { get => enemyCollider ??= GetComponentInParent<Collider>(); }
    Collider enemyCollider;
    internal EnemyHealthBarController HealthController { get => healthBarController ??= GetComponentInChildren<EnemyHealthBarController>(); }
    EnemyHealthBarController healthBarController;
    internal EnemySettings EnemySettings { get => enemySettings ??= GetComponent<EnemySettings>();}
    EnemySettings enemySettings;
}
