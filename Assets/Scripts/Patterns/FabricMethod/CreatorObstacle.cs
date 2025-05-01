using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorObstacle : Creator
{
    public GameObject prefab;

    public override GameObject createItem(Vector3 position, Quaternion rotation)
    {
        GameObject obj = Object.Instantiate(prefab, position, rotation);

        return obj;
    }
}
