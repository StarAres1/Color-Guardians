using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpState : State
{
    public override void HandleMovement(PlayerController player)
    {
        // запрещаем менять дорожку во время прыжка
    }

    public override void HandleJump(PlayerController player)
    {
        // запрещаем третий прыжок
    }
}
