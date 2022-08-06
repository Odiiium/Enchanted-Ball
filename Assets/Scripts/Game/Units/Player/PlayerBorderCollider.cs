using UnityEngine;

public class PlayerBorderCollider : MonoBehaviour
{
    internal Collider Collider { get => GetComponent<Collider>(); }
}
