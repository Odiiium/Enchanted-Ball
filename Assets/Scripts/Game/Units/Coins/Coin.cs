using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Zenject;

public class Coin : MonoBehaviour
{
    private void Start()
    {
        DoLoopRotate();
        DOVirtual.DelayedCall(2, () => Destroy(gameObject));
    }

    private void DoLoopRotate() => transform.DORotate(Vector3.up * 360, 1, RotateMode.WorldAxisAdd).SetLoops(-1);
    internal void DoJump(Vector3 jumpVector) => transform.DOJump(transform.position + jumpVector, 1, 1, 1);
    internal Vector3 RandomJumpVector() => new Vector3(Random.insideUnitCircle.x * 2, 0, Random.insideUnitCircle.y * 2);
    internal Vector3 WallRandomJumpVector(Vector3 wallPosition) => wallPosition.x > 0 ?
        new Vector3((Random.insideUnitCircle.x - 2) * 2, 0, Random.insideUnitCircle.y * 2) :
        new Vector3((Random.insideUnitCircle.x + 2) * 2, 0, Random.insideUnitCircle.y * 2);

    public class Factory : PlaceholderFactory<Coin> { } 

}
