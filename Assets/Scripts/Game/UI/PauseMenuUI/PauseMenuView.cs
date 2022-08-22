using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuView : MonoBehaviour
{
    internal PauseMenuPanel Panel { get => pauseMenuPanel ??= GetComponentInChildren<PauseMenuPanel>(); }
    PauseMenuPanel pauseMenuPanel;
    internal PauseMenuPauseButton PauseButton { get => pauseMenuPauseButton ??= GetComponentInChildren<PauseMenuPauseButton>(); }
    PauseMenuPauseButton pauseMenuPauseButton;

    internal PauseMenuRestartButton RestartButton { get => pauseMenuRestartButton ??= Panel.GetComponentInChildren<PauseMenuRestartButton>(); }
    PauseMenuRestartButton pauseMenuRestartButton;
    internal PauseMenuBackButton BackButton { get => pauseMenuBackButton ??= Panel.GetComponentInChildren<PauseMenuBackButton>(); }
    PauseMenuBackButton pauseMenuBackButton;
    internal PauseMenuExitButton ExitButton { get => pauseMenuExitButton ??= Panel.GetComponentInChildren<PauseMenuExitButton>(); }
    PauseMenuExitButton pauseMenuExitButton;
}
