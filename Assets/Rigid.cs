using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigid : MonoBehaviour {
	private Rigidbody rb;
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 movement = new Vector3 (0.0f, -300.0f, 0.0f);

		rb.AddForce (movement);
	}
}
