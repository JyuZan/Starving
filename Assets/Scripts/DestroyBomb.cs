using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBomb : MonoBehaviour {
	public float destroyTime = 10.0f;

	// Use this for initialization
	void Start () {
		if (gameObject != null) {
			Destroy (gameObject, destroyTime);
		}
	}

}
