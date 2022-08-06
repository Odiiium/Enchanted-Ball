using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBarModel : MonoBehaviour
{
    internal float PlayerHealthPoints { get => playerHealthPoints; set => playerHealthPoints = value;}
    float playerHealthPoints = 300;
    internal float PlayerMaximumHealthPoints { get => 300;}
}
