using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    internal Skin skin;
    internal Weapon currentWeapon;
    [SerializeField] Skin nextSkin;

    [Inject]
    public void Construct(Skin _skin)
    {
        skin = _skin;
    }

    private void Update()
    {
        ChangeSkin();
    }

    private void ChangeSkin()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {

        }
    }


    private void DoShot()
    {
        Ball ball = currentWeapon.Shot();
        ball.Accept(new BallProvider());
    }

}
