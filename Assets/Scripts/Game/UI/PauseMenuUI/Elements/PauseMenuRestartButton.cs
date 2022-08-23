using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

class PauseMenuRestartButton : MonoBehaviour
{
    internal Button Button { get => button ??= GetComponentInChildren<Button>(); }
    Button button;

    internal void DoRestart() => SceneManager.LoadScene("Game");
}
