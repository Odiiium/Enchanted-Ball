using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    private Skin skin;
    internal Skin Skin { get => skin ??= GetComponentInChildren<Skin>(); set => skin = value;} 

    private Weapon currentWeapon;
    private Weapon CurrentWeapon { get => currentWeapon ??= GetComponentInChildren<Weapon>(); set => currentWeapon = value; }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("W");
            DoShot();
        }
    }

    private void DoShot()
    {
        Ball ball = CurrentWeapon.Shot();
        ball.Accept(new BallProvider());
    }

}
