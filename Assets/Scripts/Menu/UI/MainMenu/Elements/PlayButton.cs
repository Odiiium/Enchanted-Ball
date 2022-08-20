using UnityEngine;
using UnityEngine.UI;

internal class PlayButton : MonoBehaviour
{
    internal Button Button { get => button ??= GetComponent<Button>(); }
    Button button;
}