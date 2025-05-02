using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    public override void HandleMovement(PlayerController player)
    {
        // запрещаем менять дорожку во время прыжка
    }

    public override void HandleJump(PlayerController player)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.rb.velocity = Vector3.up * player.jumpForce;
            player.ChangeState(new DoubleJumpState());
        }
    }
}

