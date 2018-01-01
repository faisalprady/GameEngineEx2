using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour {

	Vector3 originalPos;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		originalPos = transform.position;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < 0) {
			transform.position = originalPos;
			rb.velocity = new Vector3(0, 0, 0);
			rb.angularVelocity = new Vector3(0, 0, 0);
		}
					
	}
}
