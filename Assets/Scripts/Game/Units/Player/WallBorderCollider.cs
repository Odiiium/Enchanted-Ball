using UnityEngine;
using Zenject;

public class WallBorderCollider : MonoBehaviour
{
    GridScale gridScale;
    internal Collider Collider { get => usedCollider ??= GetComponent<Collider>(); }
    Collider usedCollider;

    [Inject]
    void Construct(GridScale _gridScale) => gridScale = _gridScale;
    private void Start() => Collider.transform.localScale = new Vector3(gridScale.xScale - 0.2f, 6, 1);
}
