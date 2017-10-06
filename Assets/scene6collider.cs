using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene6collider : MonoBehaviour {
	void OnTriggerEnter(Collider other)
	{    
		if (other.gameObject.CompareTag ("player1")) {
			GameObject player1 = GameObject.FindWithTag ("player1");
			player1.transform.position = other.transform.position.x > 20 ? new Vector3 (other.transform.position.x + 25, other.transform.position.y +2, other.transform.position.z + 10) : new Vector3 (other.transform.position.x - 25, other.transform.position.y + 2, other.transform.position.z + 10);

		}
		if (other.gameObject.CompareTag ("player2")) {
			GameObject player2 = GameObject.FindWithTag ("player2");
			player2.transform.position = other.transform.position.x > 20 ? new Vector3 (other.transform.position.x + 25, other.transform.position.y + 2, other.transform.position.z + 10) : new Vector3 (other.transform.position.x - 25, other.transform.position.y + 2, other.transform.position.z + 10);
		}
	}

}