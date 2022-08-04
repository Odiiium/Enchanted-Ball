using System.Collections;
using UnityEngine;
using Zenject;

public class PlayerMovementUIController : MonoBehaviour
{
    internal PlayerMovementUIModel Model =>
        playerMovementUIModel ??= GetComponent<PlayerMovementUIModel>();
    PlayerMovementUIModel playerMovementUIModel;
    internal PlayerMovementUIView View =>
        playerMovementUIView ??= GetComponent<PlayerMovementUIView>();
    PlayerMovementUIView playerMovementUIView;
}