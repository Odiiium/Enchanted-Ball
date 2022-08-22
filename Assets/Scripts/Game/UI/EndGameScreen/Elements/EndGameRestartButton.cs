using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EndGameRestartButton : MonoBehaviour
{
    internal Button Button { get => button ??= GetComponent<Button>(); }
    Button button;

    internal void Restart() => SceneManager.LoadScene("Game");
}