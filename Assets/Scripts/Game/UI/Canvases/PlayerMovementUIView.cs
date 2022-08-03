using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementUIView : MonoBehaviour
{
    internal Button AttackButton => attackButton ??= transform.GetChild(0).GetComponent<Button>();
    Button attackButton;
}