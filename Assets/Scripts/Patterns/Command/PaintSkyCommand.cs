using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintSkyCommand : Command
{
    
    public override void Execute()
    {
        Camera.main.backgroundColor = Color.cyan;
    }

    public override void Undo()
    {
        Camera.main.backgroundColor = new Color(196, 196, 196, 0);
    }
}
