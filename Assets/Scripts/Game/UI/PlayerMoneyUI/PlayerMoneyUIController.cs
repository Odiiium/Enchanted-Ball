using System.Collections;
using UnityEngine;
public class PlayerMoneyUIController : MonoBehaviour
{
    internal PlayerMoneyUIModel Model { get => playerMoneyUIModel ??= GetComponent<PlayerMoneyUIModel>(); }
    PlayerMoneyUIModel playerMoneyUIModel;
    internal PlayerMoneyUIView View { get => playerMoneyUIView ??= GetComponent<PlayerMoneyUIView>(); }
    PlayerMoneyUIView playerMoneyUIView;

    internal void AddCoins(int cointsToAddCount)
    {
        Model.Money += cointsToAddCount;
        View.ShowCoins(Model.Money);
    }

    internal void ReduceCoins(int coinsToReduceCount)
    {
        Model.Money -= coinsToReduceCount;
        View.ShowCoins(Model.Money);
    }
}