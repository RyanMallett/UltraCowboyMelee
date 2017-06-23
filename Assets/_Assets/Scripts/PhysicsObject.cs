using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsObject : MonoBehaviour {
	
	[Header("Physics")]
	public float weight = 1;
	
	[Header("Hold Properties")]
	public bool holdable = true;
	public float carrySize = 1;
	public int durability = 1;
	
	[Header("References")]
	public Rigidbody rb;
	public Renderer myRenderer;
	
	
	void Reset () {
		rb = GetComponent<Rigidbody>();
		myRenderer = GetComponent<Renderer>();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected void Update () {
		DoGravity();
	}
	
	void DoGravity () {
		rb.AddForce(Vector3.down * weight * Time.deltaTime);
	}
	
	
	public void Grab (Player player){
		rb.isKinematic = true;
	}
	
	public void Drop (Player player){
		rb.isKinematic = false;
		rb.AddForce(player.controller.velocity * player.throwPower, ForceMode.VelocityChange);
	}
	
	public void Highlight (){
		// myRenderer;
	}
	
	public void UnHighlight (){
		// myRenderer;
	}
}
