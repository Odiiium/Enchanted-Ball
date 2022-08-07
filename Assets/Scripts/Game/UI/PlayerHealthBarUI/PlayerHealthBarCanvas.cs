using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerHealthBarCanvas : MonoBehaviour
{
    internal PlayerHealthBarController Controller { get => playerHealthBarController ??= GetComponent<PlayerHealthBarController>(); }
    PlayerHealthBarController playerHealthBarController;

}


