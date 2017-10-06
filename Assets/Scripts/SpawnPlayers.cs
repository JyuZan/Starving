using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour {

	public Transform[] SpawnPoints;


	public GameObject[] Players;
	public GameObject player1;
	public GameObject player2;

	// Use this for initialization
	void Start () {
		player1 = Instantiate (Players[0], SpawnPoints[0].transform.position, SpawnPoints [0].transform.rotation);
		player2 = Instantiate (Players[1], SpawnPoints[1].transform.position, SpawnPoints [1].transform.rotation);
	}
		

}

