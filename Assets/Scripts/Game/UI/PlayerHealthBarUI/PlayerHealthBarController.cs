using System.Collections;
using UnityEngine;
using UniRx;

public class PlayerHealthBarController : MonoBehaviour
{
    internal PlayerHealthBarView View { get => playerHealthBarView ??= GetComponent<PlayerHealthBarView>(); }
    PlayerHealthBarView playerHealthBarView;
    internal PlayerHealthBarModel Model { get => playerHealthBarModel ??= GetComponent<PlayerHealthBarModel>(); }
    PlayerHealthBarModel playerHealthBarModel;

    internal void ReduceHealthPoints(int damage)
    {
        Model.PlayerHealthPoints -= damage;
        View.FillTheHealthBar(Model.PlayerHealthPoints, Model.PlayerMaximumHealthPoints);
    }
}