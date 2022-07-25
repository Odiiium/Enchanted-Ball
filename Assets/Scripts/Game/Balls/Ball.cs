using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Weapon weapon;
    Skin ballSkin;
    Rigidbody rigidBody;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            Hit hit = MakeHit(obstacle);
            hit.Accept(new HitProvider());
        }
    }

    private Hit MakeHit(Obstacle obstacle)
    {
        return new WallHit();
    }

    private Hit MakeHit(Enemy enemy)
    {
        return new EnemyHit();
    }

    internal void Accept(IBallVisitor ballVisitor)
    {
        ballVisitor.Visit(this);
    }


}
