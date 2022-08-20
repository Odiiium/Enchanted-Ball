using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ShopBackToMenuButton : MonoBehaviour
{
    internal Button Button { get => button ??= GetComponent<Button>(); }
    Button button;

    internal void BackToMenu(MainMenuCanvas menuCanvas, ShopCanvas shopCanvas, ShopCamera shopCamera)
    {
        shopCamera.gameObject.SetActive(false);
        shopCanvas.gameObject.SetActive(false);
        menuCanvas.gameObject.SetActive(true);
    }
}