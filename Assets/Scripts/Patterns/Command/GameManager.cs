using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager instance;
    public int combo = 0;
    private GameManager() {}

    private Command commandPaintSky;
    private Command commandPaintGround;
    public bool flagSky = false;
    public bool flagGround = false;
    List<Command> commands = new List<Command>();

    public static GameManager getInstance()
    {
        if (instance == null)
        {            
            instance = new GameManager();            
        }
        return instance;
    }

    public void setCommand(Command command)
    {
        commands.Add(command);
    }

    public void IncreaceCombo()
    {
        combo++;
        Debug.Log($"Текущее комбо: {combo}");
        switch (combo)
        {
            case 3:
                commands[0].Execute();
                flagSky = true;
                break;
            case 4:
                commands[1].Execute();
                flagGround = true;
                break;
        }
    }

    public void ResetCombo()
    {
        combo = 0;
        Debug.Log($"Fail! Комбо сброшено: {combo}");
        if (flagSky)
        {
            flagSky = false;
            commands[0].Undo();
        }
        if (flagGround)
        {
            flagGround = false;
            commands[1].Undo();
        }
    }
}
