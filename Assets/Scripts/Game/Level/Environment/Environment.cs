using UnityEngine;

internal class Environment : MonoBehaviour
{
    EnvironmentMovable environmentMovable = new EnvironmentMovable();

    internal Collider Collider { get => boxCollider ??= GetComponent<Collider>(); }
    Collider boxCollider;

    internal void Move() => environmentMovable.Move(transform);
}
