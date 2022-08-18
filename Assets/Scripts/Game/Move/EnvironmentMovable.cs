using UnityEngine;
using DG.Tweening;
internal class EnvironmentMovable : IMovable
{
    public void Move(Transform transform) => transform.DOMove(transform.position - transform.forward, 0.8f);
}
