using System.Collections;
using UnityEngine;

public class PlayerMoneyUIModel : MonoBehaviour
{
    internal int Money { get => PlayerPrefs.GetInt("Money"); set => PlayerPrefs.SetInt("Money", value); }
    internal int MoneyBeforeGameStarts {get => PlayerPrefs.GetInt("MoneyBeforeStart"); set => PlayerPrefs.SetInt("MoneyBeforeStart", value); }
}