using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class Moveable : MonoBehaviour
{
    public float speed { get; set; } = 2f;
    [field: SerializeField] public GameObject item { get; set; }

    public float deathPoint { get; set; } = 5.5f;


    void Update()
    {
        Move();
        checkDeath();
    }

    void Move()
    {
        Vector3 pos = transform.position;
        pos.x = pos.x - speed * Time.deltaTime;
        transform.position = pos;
    }

    void checkDeath()
    {
        if (transform.position.x < -deathPoint)
        {
            Destroy(item);
        }
    }
}
