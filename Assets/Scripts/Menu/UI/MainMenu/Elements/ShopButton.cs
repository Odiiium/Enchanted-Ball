using UnityEngine;
using UnityEngine.UI;

internal class ShopButton : MonoBehaviour
{
    internal Button Button { get => button ??= GetComponent<Button>(); }
    Button button;
}
