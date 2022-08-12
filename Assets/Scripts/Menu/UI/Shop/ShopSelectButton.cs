using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ShopSelectButton : MonoBehaviour
{
    internal Button Button { get => button ??= GetComponent<Button>(); }
    Button button;

    internal void SelectBall() => PlayerPrefs.SetInt("SelectedBallMaterial", PlayerPrefs.GetInt("currentBall"));


}