using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[Header("References")]
	public CharacterController controller;
	public Camera cam;
	public PhysicsObject heldObject = null;
	public Transform hand;
	
	[Header("Movement")]
    public float moveSpeed = 1000.0f;
	
	[Header("Grabbing")]
	public float grabRange = 3;
	public float grabPower = 1;
	public float throwPower = 2;
	
	void Reset () {
		controller = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
	}
	
	
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
		
		if(Input.GetButtonDown("Grab")){
			if(heldObject==null){
				AttemptGrab();
			}else{
				DropHeldObject();
			}
		}
	}
	
	
	void AttemptGrab () {
		Vector3 grabPosition = transform.position;
		Collider[] colliders = Physics.OverlapSphere(grabPosition, grabRange);
		List<PhysicsObject> grabableObjects = new List<PhysicsObject>();
        foreach (Collider hit in colliders){
            PhysicsObject po = hit.GetComponent<PhysicsObject>();
			if(po!=null && po.holdable && grabPower >= po.carrySize){
				grabableObjects.Add(po);
			}
		}
		
		if(grabableObjects.Count>0){
			PhysicsObject closest = grabableObjects[0];
			float closestDist = 9999999;
			foreach(var po in grabableObjects){
				float dist = Vector3.Distance(grabPosition,po.transform.position);
				if(dist < closestDist){
					closest = po;
					closestDist = dist;
				}
			}
			
			heldObject = closest;
			heldObject.Grab(this);
			heldObject.transform.SetParent(hand,true);
			heldObject.transform.position = hand.position;
			heldObject.transform.forward = hand.forward;
		}
	}
	
	void DropHeldObject () {
		heldObject.Drop(this);
		heldObject.transform.SetParent(null);
		heldObject = null;
	}
   


}
