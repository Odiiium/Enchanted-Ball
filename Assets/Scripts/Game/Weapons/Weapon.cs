using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    Skin skin;

    internal Ball Shot()
    {
        return new Ball();
    }

}
