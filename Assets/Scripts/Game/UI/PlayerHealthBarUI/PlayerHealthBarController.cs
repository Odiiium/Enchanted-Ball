using System.Collections;
using UnityEngine;
using UniRx;

public class PlayerHealthBarController : MonoBehaviour
{
    internal PlayerHealthBarView View { get => playerHealthBarView ??= GetComponent<PlayerHealthBarView>(); }
    PlayerHealthBarView playerHealthBarView;
    internal PlayerHealthBarModel Model { get => playerHealthBarModel ??= GetComponent<PlayerHealthBarModel>(); }
    PlayerHealthBarModel playerHealthBarModel;

    private void OnEnable()
    {
        Model.PlayerHealthPoints.Subscribe(_ => View.
            FillTheHealthBar(Model.PlayerHealthPoints.Value, Model.PlayerMaximumHealthPoints)).AddTo(this);
    }

    internal void ReduceHealthPoints(int damage) => Model.PlayerHealthPoints.Value -= damage;

}