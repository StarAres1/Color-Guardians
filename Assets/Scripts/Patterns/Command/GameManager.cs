using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager instance;
    public int combo = 0;
    private GameManager() {}

    public static GameManager getInstance()
    {
        if (instance == null)
        {
            instance = new GameManager();
        }
        return instance;
    }

    public void IncreaceCombo()
    {
        combo++;
        Debug.Log($"Текущее комбо: {combo}");
    }

    public void ResetCombo()
    {
        combo = 0;
        Debug.Log($"Fail! Комбо сброшено: {combo}");
    }
}
