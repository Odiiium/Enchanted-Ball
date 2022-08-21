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
        LevelSpawner().obstacleSpawner.obstacleList.ForEach(x => x.Move());
        LevelSpawner().wallSpawner.wallList.ForEach(x => x.Move());
        LevelSpawner().environmentSpawner.environmentList.ForEach(x => x.Move());
    }

    private void SetPlayerDamageAsDefault() => player.damage = 100;
    private void ChangeStateAfterDelay(int delay) => DOVirtual.DelayedCall(delay, () =>
    {
        if (player.playerStateMachine.currentState is not PlayerDeathState)
            player.playerStateMachine.ChangeState(new PlayerAimingState());
    });
    private LevelSpawner LevelSpawner() { return levelBuilder.levelSpawner; }
}