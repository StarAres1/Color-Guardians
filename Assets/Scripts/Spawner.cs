using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float secendsBetwenBalls = 1f;
    public float chanceChangeColor = 0.33f;
    public float chanceChangeLane = 0.33f;
    public Creator ballsFabric;
    public Creator obstacleFabric;
    float chance;
    public List<float> startZ;
    public Vector3 spawnPoint = new Vector3(10, 1, 0);

    private void ShuffleZ()
    {        
        for (int i = 0; i < startZ.Count; i++)
        {
            int randomIndex = Random.Range(i, startZ.Count);
            (startZ[i], startZ[randomIndex]) = (startZ[randomIndex], startZ[i]);
        }
    }

    void Start()
    {
        ballsFabric = Camera.main.GetComponent<CreatorPaintBall>();
        obstacleFabric = Camera.main.GetComponent<CreatorObstacle>();
        startZ = new List<float>() { -3, 0, 3 };
        ballsFabric.createItem(spawnPoint, Quaternion.identity);
        Invoke("Generate", secendsBetwenBalls);
    }

    void Generate()
    {
        ShuffleZ();
        chance = Random.value;
        if (chance < 0.3f)
        {
            spawnPoint.z = startZ[0];
            ballsFabric.createItem(spawnPoint, Quaternion.identity);
            Invoke("Generate", Random.Range(1, 4));
        }
        else if (chance < 0.5f)
        {
            spawnPoint.z = startZ[0];
            obstacleFabric.createItem(spawnPoint, Quaternion.Euler(0, -10, 0));
            Invoke("Generate", Random.Range(1, 4));
        }
        else if (chance < 0.75f)
        {
            spawnPoint.z = startZ[0];
            ballsFabric.createItem(spawnPoint, Quaternion.identity);
            spawnPoint.z = startZ[1];
            obstacleFabric.createItem(spawnPoint, Quaternion.Euler(0, -10, 0));
            Invoke("Generate", Random.Range(1, 4));
        }
        else if (chance < 0.9f)
        {
            spawnPoint.z = startZ[0];
            ballsFabric.createItem(spawnPoint, Quaternion.identity);
            spawnPoint.z = startZ[1];
            obstacleFabric.createItem(spawnPoint, Quaternion.Euler(0, -10, 0));
            spawnPoint.z = startZ[2];
            obstacleFabric.createItem(spawnPoint, Quaternion.Euler(0, -10, 0));
            Invoke("Generate", Random.Range(1, 4));
        }
        else if (chance < 0.95f)
        {
            spawnPoint.z = startZ[0];
            obstacleFabric.createItem(spawnPoint, Quaternion.Euler(0, -10, 0));
            spawnPoint.z = startZ[1];
            obstacleFabric.createItem(spawnPoint, Quaternion.Euler(0, -10, 0));
            spawnPoint.z = startZ[2];
            obstacleFabric.createItem(spawnPoint, Quaternion.Euler(0, -10, 0));
            Invoke("Generate", Random.Range(1, 4));
        }
        else
        {
            Invoke("Generate", Random.Range(1, 4));
        }
    }

    void Update()
    {
        
    }
}
