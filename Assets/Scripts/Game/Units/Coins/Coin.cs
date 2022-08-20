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
        DoJump();
        DOVirtual.DelayedCall(2, () => Destroy(gameObject));
    }

    Sequence RotateSequence()
    {
        Sequence rotateSequence = DOTween.Sequence();
        rotateSequence.Append(transform.DORotate(Vector3.up * 360, 1, RotateMode.WorldAxisAdd));
        rotateSequence.SetLoops(-1);
        return rotateSequence;
    }
    private void DoLoopRotate() => transform.DORotate(Vector3.up * 360, 1, RotateMode.WorldAxisAdd).SetLoops(-1);
    private void DoJump() => transform.DOJump(transform.position + RandomJumpVector(), 1, 1, 1);
    private Vector3 RandomJumpVector() => new Vector3(Random.insideUnitCircle.x * 2, 0, Random.insideUnitCircle.y * 2);

    public class Factory : PlaceholderFactory<Coin> { } 

}
