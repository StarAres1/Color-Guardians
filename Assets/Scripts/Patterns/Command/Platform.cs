using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public void Paint()
    {
        this.GetComponent<Renderer>().material.color = new Color32(130, 76, 31, 255);
    }

    public void UnPaint()
    {
        this.GetComponent<Renderer>().material.color = Color.gray;
    }
}
