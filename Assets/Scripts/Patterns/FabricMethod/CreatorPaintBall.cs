using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorPaintBall : Creator
{
    private Color[] colors = { Color.red, Color.blue, Color.green };
    public GameObject prefab;

    private Color GetColor()
    {
        return colors[Random.Range(0, colors.Length)];
    }


    public override GameObject createItem(Vector3 spawnPoint)
    {
        GameObject obj = Object.Instantiate(prefab, spawnPoint, Quaternion.identity);

        Renderer renderer = obj.GetComponent<Renderer>();

        if (renderer != null)
        {
            Color randomColor = GetColor();
            renderer.material.color = randomColor;

            PaintBall paintBall = obj.GetComponent<PaintBall>();
            if (paintBall != null)
            {
                paintBall.GetComponent<Renderer>().material.color = randomColor;
            }
        }
        else
        {
            Debug.Log("renderer is null");
        }

        return obj;
    }
}
