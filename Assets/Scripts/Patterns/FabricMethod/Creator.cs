using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creator
{
    public virtual GameObject createItem(Vector3 spawnPoint)
    {
        return null;
    }
}
