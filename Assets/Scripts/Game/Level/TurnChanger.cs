using UnityEngine;
using Zenject;
using UniRx;
using DG.Tweening;
using System.Linq;
using System.Collections.Generic;

public class TurnChanger : MonoBehaviour
{
    LevelBuilder levelBuilder;
    Player player;
    internal IntReactiveProperty CurrentTurn = new IntReactiveProperty(1);

    [Inject]
    void Costruct(LevelBuilder _levelBuilder, Player _player)
    {
        levelBuilder = _levelBuilder;
        player = _player;
    }

    internal void ChangeTurnToNew()
    {
        MakeEntitiesMove();
        SetPlayerDamageAsDefault();
        CurrentTurn.Value++;
        levelBuilder.BuildANewPartOfLevel();
        ChangeStateAfterDelay(1);
    }

    private void MakeEntitiesMove()
    {
        LevelSpawner().enemySpawner.enemyList.ForEach(x => x.Jump());
/*
        foreach (Enemy enemy in LevelSpawner().enemySpawner.enemyList)
            enemy.Jump();*/
        foreach (Obstacle obstacle in LevelSpawner().obstacleSpawner.obstacleList)
            obstacle.Move();
        foreach (Wall wall in LevelSpawner().wallSpawner.wallList)
            wall.Move();
        foreach (Environment environment in LevelSpawner().environmentSpawner.environmentList)
            environment.Move();
    }

    private void SetPlayerDamageAsDefault() => player.damage = 100;
    private void ChangeStateAfterDelay(int delay) => DOVirtual.DelayedCall(delay, () => player.playerStateMachine.ChangeState(new PlayerAimingState()));
    private LevelSpawner LevelSpawner() { return levelBuilder.levelSpawner; }

}