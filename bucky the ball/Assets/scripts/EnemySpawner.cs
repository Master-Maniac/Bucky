using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    Rigidbody rb;

    public Transform[] SpawnPoints;

    public GameObject BlockPrefab;

    public float TimeBetweenWaves = 10f;
    private float TimeToSpawn = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= TimeToSpawn)
        {
            BlockSpawn();
            TimeToSpawn = Time.time + TimeBetweenWaves;
        }
    }

    private void BlockSpawn()
    {
        int RandomIndex = Random.Range(0, SpawnPoints.Length);

        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            if (RandomIndex == i)
            {
                Instantiate(BlockPrefab, SpawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
