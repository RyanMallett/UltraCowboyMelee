using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSpawnManager : MonoBehaviour {

    public GameObject[] aiSpawners;

    public float aiSpawnDelay = 5.0f;
    float aiSpawnTimer;

	// Use this for initialization
	void Start () {
        aiSpawnTimer = aiSpawnDelay;
	}
	
	// Update is called once per frame
	void Update () {
        aiSpawnTimer -= Time.deltaTime;
		if (aiSpawnTimer <= 0) {
            aiSpawnTimer = aiSpawnDelay;
            aiSpawners[Random.Range(0, aiSpawners.Length)].GetComponent<AIDudeSpawner>().SpawnDude();
        }
	}
}
