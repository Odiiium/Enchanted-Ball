using UnityEngine;
using Zenject;
using UniRx;
using DG.Tweening;

public class TurnChanger : MonoBehaviour
{
    LevelBuilder levelBuilder;
    Player player;

    [Inject]
    void Costruct(LevelBuilder _levelBuilder, Player _player)
    {
        levelBuilder = _levelBuilder;
        player = _player;
    }

    internal void ChangeTurnToNew()
    {
        MakeUnitsOnLevelMove();
        DOVirtual.DelayedCall(1, () =>
            player.playerStateMachine.ChangeState(new PlayerAimingState()));
    }

    private void MakeUnitsOnLevelMove()
    {
        foreach (Enemy enemy in levelBuilder.enemyList) enemy.Jump();
        foreach (Obstacle obstacle in levelBuilder.obstacleList) obstacle.Move();
    }


}