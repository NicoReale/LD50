using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : IController
{

    PlayerModel playerModel;

    public PlayerController(PlayerModel player, PlayerView viewer)
    {
        playerModel = player;

        playerModel.onMovement += viewer.OnPlayerMove;
        playerModel.onMovement += viewer.ViewRotation;

        playerModel.onInteractResource += viewer.OnPickUp;
        playerModel.onInteractConsumator += viewer.OnUse;
    }

    public void OnUpdate()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerModel.Interact();
        }
        playerModel.Movement(horizontal);
    }
}
