using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBall : Moveable
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Color color_other = other.GetComponent<Renderer>().material.color;
            Color color_item = item.GetComponent<Renderer>().material.color;
            if (color_other != color_item)
            {
                GameManager.getInstance().ResetCombo();
            }
            else
            {
                GameManager.getInstance().IncreaceCombo();
            }
            
            Destroy(item);
        }
    }
}
