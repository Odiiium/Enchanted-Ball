using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

class PauseMenuExitButton : MonoBehaviour
{
    internal Button Button { get => button ??= GetComponentInChildren<Button>(); }
    Button button;

    internal void DoExitToMenu() => SceneManager.LoadScene("Menu");

}
