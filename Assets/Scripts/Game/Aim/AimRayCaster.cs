using System.Collections;
using UnityEngine;
using Zenject;
public class AimRayCaster : MonoBehaviour
{
    AimRay aimRay;

    [Inject]
    void Construct(AimRay _aimRay)
    {
        aimRay = _aimRay;
    }

    private void Awake() => aimRay.Line.SetPosition(1, Vector3.zero);

    void Update()
    {
        ChangeAimRaySecondPoint();
    }

    private void ChangeAimRaySecondPoint() => aimRay.Line.SetPosition(0, aimRay.secondPoint.transform.position.normalized * 4);

}