using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public AIDudeSpawner[] spawners = new AIDudeSpawner[] { };

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Submit")) {
            spawners[(int)Random.Range(0, (float)spawners.Length)].SpawnDude();
        }
	}
}
