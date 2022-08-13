using UnityEngine;
using UnityEngine.UI;
using TMPro;
internal class ShopLeftButton : MonoBehaviour
{
    internal Button Button { get => button ??= GetComponent<Button>(); }
    Button button;

    internal void SwitchToLeft(ShopUIModel model, ShopUIView view)
    {
        if (model.Display.CurrentBall == 0) model.Display.CurrentBall = model.ballMaterialArray.Length - 1;
        else model.Display.CurrentBall--;
        model.Display.ShowFullShopInformation(model, view);
    }
}
