using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {

	private Rigidbody _rb;

	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody> ();

		// Shoot forward from camera
		transform.forward = Camera.main.transform.forward;
		_rb.velocity = 2.0f * transform.forward;

	} 
}
