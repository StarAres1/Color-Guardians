using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creator: MonoBehaviour
{
    public virtual GameObject createItem(Vector3 position, Quaternion rotation)
    {
        return null;
    }
}
