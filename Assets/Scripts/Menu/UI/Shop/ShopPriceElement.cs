using UnityEngine;
using TMPro;
public class ShopPriceElement : MonoBehaviour
{
    internal TextMeshProUGUI TextElement { get => text ??= GetComponentInChildren<TextMeshProUGUI>(); }
    TextMeshProUGUI text;

}