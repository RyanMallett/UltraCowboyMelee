using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    CharacterController controller;
    Camera cam;

    public float moveSpeed = 10.0f;

    public float holdSize = 1;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movementVector = new Vector3(horizontal, 0, vertical);
        controller.SimpleMove(movementVector * moveSpeed * Time.deltaTime);

        cam.gameObject.transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X"));
        cam.gameObject.transform.Rotate(transform.right * -Input.GetAxis("Mouse Y"));

        transform.forward = cam.gameObject.transform.forward;
	}
}
