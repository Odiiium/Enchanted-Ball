using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerMovable : MonoBehaviour, IMovable
{
    private float speed = 5;

    public void Move( Transform transform)
    {
        transform.position += MoveVector(speed);
    }

    internal Vector3 MoveVector(float speed)
    {
        float moveVector = Input.GetAxis("Horizontal");
        return moveVector * Vector3.right * speed * Time.deltaTime;
    }
}
