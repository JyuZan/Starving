using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherries : MonoBehaviour {

	public bool haveFood = false;
	private GameObject player1;
	public float moveRate = 10.0f;
	private Vector3 speed;


	public Rigidbody food;

	// Use this for initialization
	void Start () {
		food = GetComponent <Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		if (haveFood) {
			transform.position = speed + player1.transform.position;
		}


	}

	void OnTriggerEnter(Collider other) 
	{    
		if (other.gameObject.CompareTag ("player1")) 
		{
			player1 = GameObject.FindWithTag ("player1");
			haveFood = true;
			InvokeRepeating ("MoveFood1", 0.1f, moveRate);
		}

	}



	void MoveFood1()
	{
		if (haveFood) {
			speed.x = Mathf.Abs(player1.transform.position.x-transform.position.x);
			speed.y = Mathf.Abs(player1.transform.position.y-(transform.position.y+5.0f));
			speed.z = Mathf.Abs(player1.transform.position.z-transform.position.z);
		} 
	}
}
