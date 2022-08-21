using System.Collections;
using UnityEngine;
public class PlayerMoneyCanvas : MonoBehaviour
{
    internal PlayerMoneyUIController Controller { get => playerMoneyUIController ??= GetComponent<PlayerMoneyUIController>(); }
    PlayerMoneyUIController playerMoneyUIController;

    private void Start() => DoStartMoneyInitialize();
    PlayerMoneyUIModel Model() { return Controller.Model; }

    private void DoStartMoneyInitialize()
    {
        Controller.View.ShowCoins(Model().Money);
        Model().MoneyBeforeGameStarts = Model().Money;
    }

}