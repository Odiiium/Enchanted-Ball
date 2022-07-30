using System.Collections;
using UnityEngine;
using Zenject;
public class AimRayCaster : MonoBehaviour
{
    AimRay aimRay;
    Player player;

    [Inject]
    void Construct(AimRay _aimRay, Player _player)
    {
        player = _player;
        aimRay = _aimRay;
    }

    private void Awake() => aimRay.Line.SetPosition(1, Vector3.zero);

    void Update()
    {
        MoveRay();
        SetupSecondPointPosition();
    }

    private void MoveRay() => aimRay.aimRayMovable.Move(aimRay.secondPoint.transform);

    private void SetupSecondPointPosition() => aimRay.Line.SetPosition(0, aimRay.secondPoint.transform.position);

}