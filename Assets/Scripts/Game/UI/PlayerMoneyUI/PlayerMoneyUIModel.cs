using System.Collections;
using UnityEngine;

public class PlayerMoneyUIModel : MonoBehaviour
{
    internal int Money { get => PlayerPrefs.GetInt("Money"); set => PlayerPrefs.SetInt("Money", value); }
}