using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBarCanvas : MonoBehaviour
{
    internal PlayerHealthBarController Controller { get => playerHealthBarController ??= GetComponent<PlayerHealthBarController>(); }
    PlayerHealthBarController playerHealthBarController;


}


