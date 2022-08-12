using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanvas : MonoBehaviour
{
    MainMenuUIController Controller { get => mainMenuUIController ??= GetComponent<MainMenuUIController>(); }
    MainMenuUIController mainMenuUIController;
}
