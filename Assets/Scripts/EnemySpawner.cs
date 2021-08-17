using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject zombie;
    public Camera cam;
    
    void Update()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnOutsideCamera();
        }
    }

    private void SpawnOutsideCamera()
    {
        Vector3 v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(Random.RandomRange(-2f, 2f), Random.RandomRange(-2f, 2f), 0));

        if (v3Pos.x < 0)
            v3Pos.x += 1f;

        if (v3Pos.y < 0)
            v3Pos.y += 1f;

        Instantiate(zombie, v3Pos, Quaternion.identity);
    }
}
