using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerMovable playerMovement;
    Skin skin;
    Weapon currentWeapon;


    Player(PlayerMovable playerMovable)
    {
        playerMovement = playerMovable;
    }

    private void DoShot()
    {
        Ball ball = currentWeapon.Shot();
        ball.Accept(new BallProvider());
    }

}
