using UnityEngine;
using Zenject;

class AimRayMovable : MonoBehaviour, IMovable
{
    float speed = 10;
    float borderXPosition = 13;
    public void Move(Transform pointTransform)
    {
        float movePositionX = pointTransform.position.x + MoveVector(speed).x;
        pointTransform.position = new Vector3(Mathf.Clamp(movePositionX, -borderXPosition, borderXPosition), 0.2f, 20);
    }

    internal Vector3 MoveVector(float speed)
    {
        float moveVector = Input.GetAxis("Horizontal");
        return moveVector * Vector3.right * speed * Time.deltaTime;
    }
}