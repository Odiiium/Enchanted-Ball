using Zenject;
using UnityEngine;

internal class CoinSpawner : MonoBehaviour
{
    internal Coin.Factory coinFactory;

    [Inject]
    void Construct(Coin.Factory _coinFactory) => coinFactory = _coinFactory;

    internal void SpawnCoin(Vector3 positionToSpawn)
    {
        Coin coin = coinFactory.Create();
        coin.transform.position = positionToSpawn + Vector3.up * 0.3f;
    }

}
