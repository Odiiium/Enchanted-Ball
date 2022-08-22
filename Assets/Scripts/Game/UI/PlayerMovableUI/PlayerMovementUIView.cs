using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementUIView : MonoBehaviour
{
    internal Button AttackButton { get => attackButton ??= transform.GetComponentInChildren<Button>(); }
    Button attackButton;
}