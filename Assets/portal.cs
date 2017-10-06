using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour {
	public Transform[] spawnpoint;
	private int index;
	// Use this for initialization
	void OnTriggerEnter(Collider other)
	{
		index = Random.Range (0,spawnpoint.Length);
		if (other.gameObject.CompareTag ("player1") || other.gameObject.CompareTag ("player2"))
		{
			other.gameObject.transform.position = spawnpoint[index].position;
		}
	}
}
