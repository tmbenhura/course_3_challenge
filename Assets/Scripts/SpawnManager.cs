using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Vector3 spawnPosition;
    public GameObject obstaclePrefab;
    public float spawnDelay = 3f;
    public float spawnRepeat = 10f;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnRepeat);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Spawn()
    {
        if (!playerController.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }
    }
}
