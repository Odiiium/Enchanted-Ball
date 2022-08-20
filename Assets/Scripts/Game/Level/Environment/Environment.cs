using UnityEngine;
using Zenject;
internal class Environment : MonoBehaviour
{
    internal DiContainer diContainer;
    internal EnvironmentMovable EnvironmentMovable { get => environmentMovable ??= diContainer.Resolve<EnvironmentMovable>(); }
    EnvironmentMovable environmentMovable;

    [Inject]
    void Construct(DiContainer _diContainer) => diContainer = _diContainer;

    internal Collider Collider { get => boxCollider ??= GetComponent<Collider>(); }
    Collider boxCollider;

    internal void Move() => EnvironmentMovable.Move(transform);
}
