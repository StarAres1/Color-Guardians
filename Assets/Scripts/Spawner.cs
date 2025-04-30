using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float secendsBetwenBalls = 1f;
    public float chanceChangeColor = 0.33f;
    public float chanceChangeLane = 0.33f;
    public GameObject paintBallPrefab;
    public Vector3 startPosition = new Vector3(10, 0.55f, 0);
    CreatorPaintBall ballsFabric = new CreatorPaintBall();

    void Start()
    {
        ballsFabric = new CreatorPaintBall();
        ballsFabric.prefab = paintBallPrefab;
        ballsFabric.createItem(startPosition);
        Invoke("GeneratePaintBall", secendsBetwenBalls);
    }

    void GeneratePaintBall()
    {
        ballsFabric.createItem(startPosition);
        Invoke("GeneratePaintBall", secendsBetwenBalls);
    }

    void Update()
    {
        
    }
}
