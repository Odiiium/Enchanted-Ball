using System.Collections;
using UnityEngine;

public class EndGameUICanvas : MonoBehaviour
{
    internal EndGameUIController Controller { get => endGameUIController ??= GetComponent<EndGameUIController>(); }
    EndGameUIController endGameUIController;

}