using UnityEngine;
using System.Collections.Generic;
using Zenject;
using UniRx;

internal class Environment : MonoBehaviour
{
    EnvironmentMovable environmentMovable = new EnvironmentMovable();

    internal Collider Collider { get => boxCollider ??= GetComponent<Collider>(); }
    Collider boxCollider;
    public class Factory : PlaceholderFactory<Environment> { }

    internal void Move() => environmentMovable.Move(transform);


}
