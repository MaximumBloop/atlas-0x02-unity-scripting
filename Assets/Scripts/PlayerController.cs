using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W))
		{
			rb.AddForce(Vector3.forward * speed - rb.velocity);
		} else if (Input.GetKey(KeyCode.D))
		{
			rb.AddForce(Vector3.right * speed - rb.velocity);
		} else if (Input.GetKey(KeyCode.S))
		{
			rb.AddForce(Vector3.back * speed - rb.velocity);
		} else if (Input.GetKey(KeyCode.A))
		{
			rb.AddForce(Vector3.left * speed - rb.velocity);
		} else {
			rb.velocity = new Vector3(0, 0, 0);
		}
	}
}
