using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public virtual void HandleMovement(PlayerController player)
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && player.currentLane > 0)
        {
            player.currentLane--;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && player.currentLane < 2)
        {
            player.currentLane++;
        }
    }
    public virtual void HandleColorChange(PlayerController player) 
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            player.render.material.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            player.render.material.color = Color.green;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            player.render.material.color = Color.blue;
        }
    }
    public virtual void HandleJump(PlayerController player) 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.rb.velocity = Vector3.up * player.jumpForce;
            player.ChangeState(new JumpState());
        }
    }
}
