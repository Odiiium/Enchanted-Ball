using UnityEngine;
using Zenject;

public class BallMovable : MonoBehaviour , IMovable
{
    AimRay aimRay;
    Rigidbody RigidBody { get => rigidBody ??= gameObject.GetComponent<Rigidbody>(); }
    Rigidbody rigidBody;

    [Inject]
    void Construct(AimRay _aimRay)
    {
        aimRay = _aimRay;
    }

    public void Move(Transform playerTransform)
    {
        RigidBody.AddForce(aimRay.secondPoint.transform.position - playerTransform.position, ForceMode.Impulse);
    }
}
