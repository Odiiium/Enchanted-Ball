using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerHealthBarModel : MonoBehaviour
{
    internal FloatReactiveProperty PlayerHealthPoints = new FloatReactiveProperty(300);
    internal float PlayerMaximumHealthPoints { get => 300;}

}
