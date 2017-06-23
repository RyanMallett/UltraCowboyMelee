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

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        Vector3 movementDirection = new Vector3(horizontal * forward.x, 0, vertical * forward.z);
        controller.SimpleMove(forward * vertical * moveSpeed * Time.deltaTime);
        controller.SimpleMove(right * horizontal * moveSpeed * Time.deltaTime);


        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"));
        cam.gameObject.transform.Rotate(Vector3.right, -Input.GetAxis("Mouse Y"));        
	}
}
