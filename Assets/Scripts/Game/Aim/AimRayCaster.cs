using System.Collections;
using UnityEngine;
using Zenject;
public class AimRayCaster : MonoBehaviour
{
    AimRay aimRay;
    Ray ray;
    RaycastHit hit;
    Vector3 hitPoint = new Vector3(0, 0, 3);

    [Inject]
    void Construct(AimRay _aimRay) => aimRay = _aimRay;

    private void Awake()
    {
        aimRay.Line.SetPosition(1, Vector3.up* 0.2f);
        aimRay.secondPoint.transform.position = hitPoint;
    }
    void Update()
    {
        ChangeAimRaySecondPoint();
    }
        private void ChangeAimRaySecondPoint() => aimRay.Line.SetPosition(0, aimRay.secondPoint.transform.position.normalized * 4);

    private void ChangeSecoindPointPositionOnMouse()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            if (mousePosition.x < Screen.width * 0.85f & mousePosition.y > Screen.height * 0.3f)
            {
                ray = Camera.main.ScreenPointToRay(mousePosition);
            }
            if (Physics.Raycast(ray, out hit, 100))
            {
                aimRay.secondPoint.transform.position = hit.point;
            }
            else aimRay.secondPoint.transform.position = hitPoint;
        }
    }


    private void ChangeSecondPointPosition()
    {
        if (Input.touchCount > 0)
        {
            RaycastHit hit;
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            if (Physics.Raycast(ray, out hit, 100)) aimRay.secondPoint.transform.position = hit.point;
            else aimRay.secondPoint.transform.position = hitPoint;
        }
    }

}