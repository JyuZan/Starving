using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderer : MonoBehaviour {
	//public Transform[] SpawnPoints;
	public GameObject[] player;

	void OnParticleCollision(GameObject other) {
		if (other.tag == "player1" || other.tag == "player2") {
			other.transform.position = other.transform.position.x > 0 ? new Vector3 (other.transform.position.x + 20, other.transform.position.y, other.transform.position.z) : new Vector3 (other.transform.position.x - 20, other.transform.position.y, other.transform.position.z);

		}
		if (other.CompareTag ("Food")) {
			Debug.Log ("Fodd 1");
			
		}

	}
}
