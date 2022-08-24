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
    internal void SpawnCoins(Vector3 positionToSpawn, Object obj, int coinsCount)
    {
        int CoinsCountToSpawn = Random.Range(1, coinsCount);
        for (int i = 0; i < CoinsCountToSpawn; i++)
        {
            Coin coin = coinFactory.Create();
            coin.transform.position = positionToSpawn + Vector3.up * 0.3f;

            if (obj is Enemy) coin.DoJump(coin.RandomJumpVector());
            else if (obj is Wall) coin.DoJump(coin.WallRandomJumpVector(positionToSpawn));
        }
        playerMoneyCanvas.Controller.AddCoins(CoinsCountToSpawn);
    }

}
