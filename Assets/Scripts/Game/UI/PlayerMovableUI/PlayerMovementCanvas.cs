using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;
using UnityEngine.EventSystems;

public class PlayerMovementCanvas : MonoBehaviour
{
    internal PlayerMovementUIController Controller { get => playerMovementUIController ??= gameObject.GetComponent<PlayerMovementUIController>(); }
    PlayerMovementUIController playerMovementUIController;

}
