using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFoods : MonoBehaviour {

	public Transform[] SpawnPoints;
	public float spawnTime = 30.0f;

	public GameObject[] Food;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnFood", 1f, spawnTime);
	}

	// Update is called once per frame
	void Update () {
		
	}

	void SpawnFood()
	{
		int spawnIndex = Random.Range (0, SpawnPoints.Length);
		int FoodIndex = Random.Range (0, Food.Length);
		Instantiate (Food[FoodIndex],SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);
	}
}
