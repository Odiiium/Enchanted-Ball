using Zenject;
using UnityEngine;

internal class CoinSpawner : MonoBehaviour
{
    internal Coin.Factory coinFactory;
    internal PlayerMoneyCanvas playerMoneyCanvas { get => diContainer.Resolve<PlayerMoneyCanvas>(); }
    DiContainer diContainer;

    [Inject]
    void Construct(Coin.Factory _coinFactory, DiContainer _diContainer)
    {
        diContainer = _diContainer; 
        coinFactory = _coinFactory;
    }
    internal void SpawnCoins(Vector3 positionToSpawn)
    {
        int CoinsCountToSpawn = Random.Range(1, 6);
        for (int i = 0; i < CoinsCountToSpawn; i++)
        {
            Coin coin = coinFactory.Create();
            coin.transform.position = positionToSpawn + Vector3.up * 0.3f;
        }
        playerMoneyCanvas.Controller.AddCoins(CoinsCountToSpawn);
    }

}
