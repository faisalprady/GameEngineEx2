using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {

	public GameObject player;
    private Vector3 offset;
	private Vector3 rotate;
	public float horizontalSpeed;

	public bool useMouseRotation = false;
	private float yAxisRotation = 0;
	private Quaternion originalRotation;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
        offset = transform.position - player.transform.position;
		originalRotation = gameObject.transform.rotation;

		Cursor.lockState = CursorLockMode.Locked;


	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position= player.transform.position + offset;
		transform.rotation = originalRotation;
		if (useMouseRotation == true) {
			yAxisRotation += horizontalSpeed * Input.GetAxis("Mouse X");
		}

		//rotate = new Vector3(0, yAxisRotation, 0);
		//Debug.Log (player.transform.position);
		transform.RotateAround(player.transform.position, Vector3.up , yAxisRotation);
        //transform.position = player.transform.position + offset;
		//transform.LookAt(player.transform.position,Vector3.up);
		//rotate = originalRotation;
	}
}
