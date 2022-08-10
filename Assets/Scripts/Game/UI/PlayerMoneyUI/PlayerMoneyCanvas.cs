using System.Collections;
using UnityEngine;
public class PlayerMoneyCanvas : MonoBehaviour
{
    internal PlayerMoneyUIController Controller { get => playerMoneyUIController ??= GetComponent<PlayerMoneyUIController>(); }
    PlayerMoneyUIController playerMoneyUIController;

    private void Start() => Controller.View.ShowCoins(Controller.Model.Money);
}