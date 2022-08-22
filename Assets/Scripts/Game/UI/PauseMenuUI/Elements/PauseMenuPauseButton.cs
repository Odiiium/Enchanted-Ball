using UnityEngine.UI;
using UnityEngine;

class PauseMenuPauseButton : MonoBehaviour
{
    internal Button Button { get => button ??= GetComponentInChildren<Button>(); }
    Button button;

    internal void MakePause(PauseMenuPanel pausePanel, PlayerMovementCanvas playerMovementCanvas)
    {
        OpenPauseMenu(pausePanel);
        CloseMovementMenu(playerMovementCanvas);
    }

    void OpenPauseMenu(PauseMenuPanel pausePanel) => pausePanel.gameObject.SetActive(true);
    void CloseMovementMenu(PlayerMovementCanvas moveCanvas) => moveCanvas.gameObject.SetActive(false);


}
