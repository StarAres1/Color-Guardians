using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager instance;
    public int combo = 0;
    private GameManager() {}

    private static Command commandPaintSky;

    public static GameManager getInstance()
    {
        if (instance == null)
        {            
            instance = new GameManager();            
        }
        return instance;
    }

    public void setCommands()
    {
        commandPaintSky = new PaintSkyCommand();
    }

    public void IncreaceCombo()
    {
        combo++;
        Debug.Log($"Текущее комбо: {combo}");
        PantWorld();

    }

    public void ResetCombo()
    {
        combo = 0;
        Debug.Log($"Fail! Комбо сброшено: {combo}");
        PantWorld();
    }

    public void PantWorld()
    {
        switch (combo)
        {
            case 0: commandPaintSky.Undo(); break;
            case 3: commandPaintSky.Execute(); break;
        }
    }
}
