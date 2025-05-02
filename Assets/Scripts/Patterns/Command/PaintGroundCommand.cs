using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintGroundCommand : Command
{
    public Platform platform;

    public PaintGroundCommand(Platform platform)
    {
        this.platform = platform;
    }

    public override void Execute()
    {
        platform.Paint();
    }

    public override void Undo()
    {
        platform.UnPaint();
    }
}
