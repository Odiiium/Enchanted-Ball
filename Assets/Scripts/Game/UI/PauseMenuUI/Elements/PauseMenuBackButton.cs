using UnityEngine;
using UnityEngine.UI;
class PauseMenuBackButton : MonoBehaviour
{
    internal Button Button { get => button ??= GetComponentInChildren<Button>(); }
    Button button;
    
    internal void GoBackToTheGame(PauseMenuPanel pausePanel, PlayerMovementCanvas playerMovementCanvas, Player player)
    {
        ClosePauseMenu(pausePanel);
        OpenMovementMenu(playerMovementCanvas, player); 
    }

    void ClosePauseMenu(PauseMenuPanel pausePanel) => pausePanel.gameObject.SetActive(false);
    void OpenMovementMenu(PlayerMovementCanvas moveCanvas, Player player)
    {
        if (player.playerStateMachine.currentState is PlayerAimingState)
            moveCanvas.gameObject.SetActive(true);
    }

}
