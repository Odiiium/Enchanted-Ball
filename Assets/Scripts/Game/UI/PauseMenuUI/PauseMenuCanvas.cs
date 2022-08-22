using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuCanvas : MonoBehaviour
{
    internal PauseMenuController Controller { get => pauseMenuController ??= GetComponent<PauseMenuController>(); }
    PauseMenuController pauseMenuController;

}
