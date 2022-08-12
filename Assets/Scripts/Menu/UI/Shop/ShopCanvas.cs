using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCanvas : MonoBehaviour
{
    internal ShopUIController Controller { get => shopUIController ??= GetComponent<ShopUIController>(); }
    ShopUIController shopUIController;
}
