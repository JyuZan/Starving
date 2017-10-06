using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class Player2Controller : MonoBehaviour {

	public float speed;
	public float jumpheight;

	private Rigidbody rb;
	private bool grounded;


	void Start ()
	{
		rb = GetComponent<Rigidbody>();

	}

	void Update()
	{
		//Jump
		if (Input.GetKeyDown ("/") && true) 
		{
			Vector3 jump = new Vector3 (0.0f, jumpheight, 0.0f);
			rb.AddForce (jump);
			grounded = false;
		}

	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal_player_2");
		float moveVertical = Input.GetAxis ("Vertical_player_2");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	//check if ball is on the ground
	void OnCollisionEnter(Collision hit)
	{
		if (hit.gameObject.tag == "Ground")
		{
			grounded = true;
		}
	}

}


