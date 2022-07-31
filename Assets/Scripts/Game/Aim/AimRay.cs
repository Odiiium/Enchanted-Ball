using System.Collections;
using UnityEngine;
using Zenject;

public class AimRay : MonoBehaviour
{
    internal AimRayMovable aimRayMovable;
    internal FirstPoint firstPoint;
    internal SecondPoint secondPoint;

    internal LineRenderer Line { get => line ??= GetComponent<LineRenderer>(); }
    private LineRenderer line;

    [Inject]
    void Construct(AimRayMovable _aimRayMovable, FirstPoint _firstPoint, SecondPoint _secondPoint)
    {
        aimRayMovable = _aimRayMovable;
        firstPoint = _firstPoint;
        secondPoint = _secondPoint;
    }
}