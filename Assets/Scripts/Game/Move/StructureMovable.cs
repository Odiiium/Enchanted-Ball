using DG.Tweening;
using UnityEngine;

public class StructureMovable : MonoBehaviour, IMovable
{
    public void Move(Transform transform) => transform.DOMove(transform.position - transform.forward, 0.8f);
}