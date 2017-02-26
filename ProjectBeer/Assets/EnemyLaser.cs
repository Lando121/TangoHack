using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour {

	private Rigidbody _rb;

	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody> ();

		// Shoot towards player camera
		transform.forward = (Camera.main.transform.position - transform.position).normalized;
		_rb.velocity = (Camera.main.transform.position - transform.position).normalized * 0.75f;
	
	}
}
