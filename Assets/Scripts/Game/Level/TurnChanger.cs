using UnityEngine;
using Zenject;
using UniRx;
using DG.Tweening;

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
        MakeUnitsOnLevelMove();
        SetPlayerDamageAsDefault();
        CurrentTurn.Value++;
        levelBuilder.BuildANewPartOfLevel();
        ChangeStateAfterDelay(1);
    }

    private void MakeUnitsOnLevelMove()
    {
        foreach (Enemy enemy in levelBuilder.levelSpawner.enemySpawner.enemyList)
            enemy.Jump();
        foreach (Obstacle obstacle in levelBuilder.levelSpawner.obstacleSpawner.obstacleList)
            obstacle.Move();
        foreach (Wall obstacle in levelBuilder.levelSpawner.wallSpawner.wallList)
            obstacle.Move();
    }

    private void SetPlayerDamageAsDefault() => player.damage = 100;
    private void ChangeStateAfterDelay(int delay) => DOVirtual.DelayedCall(delay, () => player.playerStateMachine.ChangeState(new PlayerAimingState()));


}