using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager
{
    private static GameManager instance;
    private GameManager() {}

    private Command commandPaintSky;
    private Command commandPaintGround;
    public bool flagSky = false;
    public bool flagGround = false;
    List<Command> commands = new List<Command>();

    public int life = 3;
    public int combo = 0;
    public int score = 0;

    public Text scoreText;
    public Text comboText;
    public Text lifeText;


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
        Debug.Log($"Текущее комбо: {combo}");
        UpdateScore(true);
        switch (combo)
        {
            case 3:
                commands[0].Execute();
                flagSky = true;
                break;
            case 6:
                commands[1].Execute();
                flagGround = true;
                break;
        }
    }

    public void ResetCombo()
    {
        UpdateScore(false);
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

    public void UpdateScore(bool flag)
    {
        if (flag)
        {
            score++;
            combo++;
            scoreText.text = $"Score: {score}";
            if (combo >= 3)
            {
                comboText.text = $"x{combo}";
            }
            if (score >= 20)
            {
                comboText.text = "You win!!!";
                Time.timeScale = 0;
            }
        }
        else
        {
            comboText.text = "";

            if (combo < 3)
            {
                life--;
                if (life == 0)
                {
                    comboText.text = "GAME OVER";
                    lifeText.text = "";
                    Time.timeScale = 0;
                }
                else
                {
                    lifeText.text = lifeText.text[..(life + 1)];
                }
            }

            combo = 0;

            GameObject[] objects = GameObject.FindGameObjectsWithTag("PaintBall");

            foreach (GameObject obj in objects)
            {
                Object.Destroy(obj);
            }

            objects = GameObject.FindGameObjectsWithTag("Obstacle");

            foreach (GameObject obj in objects)
            {
                Object.Destroy(obj);
            }
        }
    }
}
