using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDudeSpawner : MonoBehaviour {

    public GameObject aiDude;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnDude() {
        Instantiate(aiDude, transform.position, transform.rotation);
    }
}
