using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDude : MonoBehaviour {

    GameObject player;
    Player playerScript;

    public float aiMoveSpeed;

	// Use this for initialization
	void Start () {
        player =  GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, player.gameObject.transform.position, aiMoveSpeed * Time.deltaTime);
	}
}
