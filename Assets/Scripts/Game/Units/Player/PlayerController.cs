using System.Collections;
using UnityEngine;
using Zenject;
public class PlayerController : MonoBehaviour
{
    Player player;
    PlayerMovable playerMovement;

    [Inject]
    public void Construct(Player _player, PlayerMovable _playerMovable)
    {
        player = _player;
        playerMovement = _playerMovable;
    }

    private void Update()
    {
        playerMovement.Move(player.transform);
    }
}