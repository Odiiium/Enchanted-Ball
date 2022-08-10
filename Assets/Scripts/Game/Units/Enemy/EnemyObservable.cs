using System.Collections.Generic;
using UniRx;
using Zenject;
using DG.Tweening;
using UnityEngine;
using UniRx.Triggers;
internal class EnemyObservable
{
    internal void SubscribeToObservables(Enemy enemyToSpawn, List<Enemy> enemyList, DiContainer diContainer)
    {
        SubscribeToHealthChangedEvent(enemyToSpawn, enemyList, diContainer);
        SubscribeToCollisionDetectionEvent(enemyToSpawn, enemyList, diContainer.Resolve<Player>());
        SubscibeToTriggerDetectionEvent(enemyToSpawn, enemyList);
    }

    void SubscribeToHealthChangedEvent(Enemy enemyToSpawn, List<Enemy> enemyList, DiContainer diContainer)
    {
        CoinSpawner coinSpawner = diContainer.Resolve<CoinSpawner>();
        EnemyHealth(enemyToSpawn).
            Where(_ => EnemyHealth(enemyToSpawn).Value <= 0).
            Subscribe(_ =>
            {
                enemyToSpawn.Die(enemyToSpawn, enemyList);
                coinSpawner.SpawnCoins(enemyToSpawn.transform.position);
            }).
            AddTo(enemyToSpawn);
    }

    void SubscribeToCollisionDetectionEvent(Enemy enemyToSpawn, List<Enemy> enemyList, Player player)
    {
        enemyToSpawn.Model.Collider.OnCollisionEnterAsObservable().
            Subscribe(collision =>
            {
                if (collision.gameObject.layer == 7)
                { 
                    EnemyHealth(enemyToSpawn).Value -= player.damage;
                    enemyToSpawn.transform.DOShakeScale(1, new Vector3(.25f, .25f, .25f), 4, 50);
                }
            }
            ).AddTo(enemyToSpawn);
    }

    void SubscibeToTriggerDetectionEvent(Enemy enemyToSpawn, List<Enemy> enemyList)
    {
        enemyToSpawn.Model.Collider.OnTriggerEnterAsObservable().
            Subscribe(collision =>
            {
                if (collision.gameObject.layer == 8)
                    enemyToSpawn.Attack();
                enemyToSpawn.Die(enemyToSpawn, enemyList);
            }
            ).AddTo(enemyToSpawn);
    }   
    
    FloatReactiveProperty EnemyHealth(Enemy enemyToSpawn) => enemyToSpawn.Model.HealthController.Model.HealthPoints;

}
