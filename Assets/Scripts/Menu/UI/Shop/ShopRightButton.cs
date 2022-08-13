using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopRightButton : MonoBehaviour
{
    internal Button Button { get => button ??= GetComponent<Button>(); }
    Button button;
    internal void SwitchToRight(ShopUIModel model, ShopUIView view)
    {
        if (model.Display.CurrentBall == model.ballMaterialArray.Length - 1) model.Display.CurrentBall = 0;
        else model.Display.CurrentBall++;
        model.Display.ShowFullShopInformation(model, view);
    }
}