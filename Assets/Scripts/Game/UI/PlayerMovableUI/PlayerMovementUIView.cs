using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementUIView : MonoBehaviour
{
    internal Button AttackButton { get => attackButton ??= transform.GetChild(0).GetComponent<Button>(); }
    Button attackButton;

    internal Button MoveRayRightButton { get => moveRayRightButton ??= transform.GetChild(1).GetComponent<Button>(); }
    Button moveRayRightButton;

    internal Button MoveRayLeftButton { get => moveRayLeftButton ??= transform.GetChild(2).GetComponent<Button>(); }
    Button moveRayLeftButton;

    internal RightAimMoveButton MoveRayRightButtonHandler { get => moveRayRightButtonHandler ??= transform.GetChild(1).GetComponent<RightAimMoveButton>(); }
    RightAimMoveButton moveRayRightButtonHandler;

    internal LeftAimMoveButton LeftAimMoveButtonHandler { get => leftAimMoveButtonHandler ??= transform.GetChild(2).GetComponent<LeftAimMoveButton>(); }
    LeftAimMoveButton leftAimMoveButtonHandler;



}