using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameBackToMenuButton : MonoBehaviour
{
    internal Button Button { get => button ??= GetComponent<Button>();}
    Button button;

    internal void BackToMenu() => SceneManager.LoadScene("Menu");
}