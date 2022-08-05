using DG.Tweening;
using UnityEngine;

public class EnemyMovable : MonoBehaviour, IMovable
{
    public void Move(Transform transform)
    {
        transform.DOJump(transform.position + transform.forward, .4f, 0, .8f);
    }
}
