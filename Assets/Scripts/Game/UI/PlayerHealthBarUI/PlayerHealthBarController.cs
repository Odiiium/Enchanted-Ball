using System.Collections;
using UnityEngine;
using UniRx;

public class PlayerHealthBarController : MonoBehaviour
{
    internal PlayerHealthBarView View { get => playerHealthBarView ??= GetComponent<PlayerHealthBarView>(); }
    PlayerHealthBarView playerHealthBarView;
    internal PlayerHealthBarModel Model { get => playerHealthBarModel ??= GetComponent<PlayerHealthBarModel>(); }
    PlayerHealthBarModel playerHealthBarModel;

    private void Awake()
    {
        Model.PlayerHealthPoints.Subscribe(value => View.
        FillTheHealthBar(value, Model.PlayerMaximumHealthPoints)).AddTo(this);
        Model.PlayerHealthPoints.Where(value => value <= 0).Subscribe(value =>
        {
            Model.EndGameCanvas.gameObject.SetActive(true);
            Model.Player.playerStateMachine.ChangeState(new PlayerDeathState());
        }).AddTo(this);
    }

    internal void ReduceHealthPoints(int damage) => Model.PlayerHealthPoints.Value -= damage;

}