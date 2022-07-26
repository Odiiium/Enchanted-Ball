using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Skin skin;

    internal Ball Shot()
    {
        return new Ball();
    }

}
