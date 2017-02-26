using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public int m_Health;

	void OnTriggerEnter (Collider col) {
		if (col.CompareTag ("Enemy Laser")) {
			m_Health -= 1;
			if (m_Health <= 0) {
				Die ();
			}
		}
	}

	void Die () {
		// TO-DO 
		Debug.Log ("DIE");
	}
}
