using System.Collections.Generic;
using UniRx;
using Zenject;
using DG.Tweening;
using UnityEngine;
using UniRx.Triggers;
internal class EnemyObservable
{
    internal void SubscribeToObservables(Enemy enemy, List<Enemy> enemyList, DiContainer diContainer)
    {
        SubscribeToHealthChangedEvent(enemy, enemyList, diContainer);
        SubscribeToCollisionDetectionEvent(enemy, enemyList, diContainer.Resolve<Player>());
        SubscibeToTriggerDetectionEvent(enemy, enemyList);
    }

    void SubscribeToHealthChangedEvent(Enemy enemy, List<Enemy> enemyList, DiContainer diContainer)
    {
        CoinSpawner coinSpawner = diContainer.Resolve<CoinSpawner>();
        EnemyHealth(enemy).
            Where(_ => EnemyHealth(enemy).Value <= 0).
            Subscribe(_ =>
            {
                enemy.Die(enemy, enemyList);
                coinSpawner.SpawnCoins(enemy.transform.position, enemy, 6);
            }).
            AddTo(enemy);
    }

    void SubscribeToCollisionDetectionEvent(Enemy enemy, List<Enemy> enemyList, Player player)
    {
        enemy.Model.Collider.OnCollisionEnterAsObservable().
            Subscribe(collision =>
            {
                if (collision.gameObject.layer == 7)
                { 
                    EnemyHealth(enemy).Value -= player.damage;
                    enemy.transform.DOPunchScale(Vector3.one * .25f, .3f, 3);
                    enemy.Model.AudioSource.Play();
                }
            }
            ).AddTo(enemy);
    }

    void SubscibeToTriggerDetectionEvent(Enemy enemy, List<Enemy> enemyList)
    {
        enemy.Model.Collider.OnTriggerEnterAsObservable().
            Subscribe(collision =>
            {
                if (collision.gameObject.layer == 8)
                    enemy.Attack();
                enemy.Die(enemy, enemyList);
            }
            ).AddTo(enemy);
    }   
    
    FloatReactiveProperty EnemyHealth(Enemy enemyToSpawn) => enemyToSpawn.Model.HealthController.Model.HealthPoints;

}
