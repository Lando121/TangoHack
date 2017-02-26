using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawns : MonoBehaviour {
    public float moveSpeed = 0.01f;
	private int randomTime = Random.Range(1, 5);
    private float randomSpeed;
    private Vector3 startingPoint;
    private Vector3 startingRotation;
    private Transform start;

	private float shootTimer = 0.0f;

	public GameObject laser;
	private AudioSource _as;

	// Use this for initialization
	void Start () {

		_as = GetComponent<AudioSource> ();

        randomSpeed = Random.Range(0.005f, 0.001f);
		startingPoint = transform.localPosition;
		startingRotation = transform.localRotation.eulerAngles;

    }   

    // Update is called once per frame
    void Update () {

		if ((transform.position - startingPoint).magnitude < 0.2) {
			transform.position += -transform.forward * moveSpeed;
		} else {
			Circulate ();
		}

		if (shootTimer > 2.5f) {
			GameObject temp = Instantiate (laser);
			temp.transform.position = this.transform.position + new Vector3(0, 0, 0.05f);
			shootTimer = 0;
			_as.Play ();
		}
			
		shootTimer += Time.deltaTime;

    }

    void Circulate()
    {
		transform.position += transform.up * Mathf.Sin(Time.time + randomTime) * randomSpeed;
		transform.position += transform.right * Mathf.Cos(Time.time + randomTime) * randomSpeed;
    }

	void OnTriggerEnter (Collider col ) {
		if (col.gameObject.CompareTag("Laser")) {
			Die ();
			Destroy (col.gameObject);
		}
	}

	void Die() {
		_as.Stop ();
		_as.clip = Resources.Load ("Audio/Pow.mp3") as AudioClip;
		_as.Play ();
		Destroy (this.gameObject);
	}
}
