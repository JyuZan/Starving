using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Croissant : MonoBehaviour {

	public bool haveFood = false;
	private GameObject player2;
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
			transform.position = speed + player2.transform.position;
		}


	}

	void OnTriggerEnter(Collider other) 
	{    
		if (other.gameObject.CompareTag ("player2")) 
		{
			player2 = GameObject.FindWithTag ("player2");
			haveFood = true;
			InvokeRepeating ("MoveFood2", 0.1f, moveRate);
		}

	}



	void MoveFood2()
	{
		if (haveFood) {
			speed.x = Mathf.Abs(player2.transform.position.x-transform.position.x);
			speed.y = Mathf.Abs(player2.transform.position.y-(transform.position.y+5.0f));
			speed.z = Mathf.Abs(player2.transform.position.z-transform.position.z);
		} 
	}
}
