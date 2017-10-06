using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	GameObject platform;
	[SerializeField]
	Transform platforms;

	[SerializeField]
	Transform startposition;

	[SerializeField]
	Transform endposition;

	[SerializeField]
	float platformSpeed;


	Vector3 direction;
	Transform destination;

	// Use this for initialization
	void Start () {
		SetDestination (startposition);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		platforms.GetComponent<Rigidbody>().MovePosition(platforms.position + direction * platformSpeed * Time.fixedDeltaTime);﻿
		if (Vector3.Distance (platforms.position, destination.position) < platformSpeed * Time.fixedDeltaTime) {
			SetDestination (destination == startposition ? endposition : startposition);
		}
	}
	void OnDrawGizmos(){
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube (startposition.position, platforms.localScale);

		Gizmos.color = Color.red;
		Gizmos.DrawWireCube (endposition.position, platforms.localScale);
	}

	void SetDestination(Transform dest){
		destination = dest;
		direction = (destination.position - platforms.position).normalized;
	}
}
