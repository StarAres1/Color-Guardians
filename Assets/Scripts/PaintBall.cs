using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBall : MonoBehaviour
{

    public float speedBall = 2f;
    public GameObject paintBall;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = pos.x - speedBall * Time.deltaTime;
        transform.position = pos;

        if (transform.position.x < -5.5f)
        {
            Destroy(paintBall);
        }
    }

    
}
