using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPortal : MonoBehaviour {
	public Transform[] SpawnPoints;
	public float spawnTime = 30.0f;
	public GameObject Portal;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnFood", 1f, spawnTime);
	}
		
	void SpawnFood()
	{
		int spawnIndex = Random.Range (0, SpawnPoints.Length);
		Instantiate (Portal,SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);
	}
}
