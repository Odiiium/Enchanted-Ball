using UnityEngine;
using Zenject;

class AimRayMovable : MonoBehaviour, IMovable
{
    float speed = 4;
    float borderXPosition = 3.5f;
    float aimLength = 1;
    public void Move(Transform pointTransform)
    {
        float movePositionX = pointTransform.position.x + MoveVector(speed).x;
        pointTransform.position = new Vector3(Mathf.Clamp(movePositionX, -borderXPosition, borderXPosition), 0.2f, aimLength);
    }

    public void MoveLeft(Transform pointTransform)
    {
        float movePositionX = pointTransform.position.x + MoveVector(-speed).x;
        pointTransform.position = new Vector3(Mathf.Clamp(movePositionX, -borderXPosition, borderXPosition), 0.2f, aimLength);
    }

    internal Vector3 MoveVector(float speed)
    {
        return Vector3.right * speed * Time.deltaTime;
    }
}