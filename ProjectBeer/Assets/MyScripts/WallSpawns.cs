using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawns : MonoBehaviour {
    public float moveSpeed = 1;
    private float randomSpeed;

	// Use this for initialization
	void Start () {
        randomSpeed = Random.RandomRange(0.005f, 0.02f);
    }   

    // Update is called once per frame
    void Update () {
        transform.LookAt(Camera.main.transform);
        float distance = (transform.position - Camera.main.transform.position).magnitude;

        if ( distance > 5)
        {
            Approach();
            return;
        } else if ( distance < 2)
        {
            BackUp();
            return;
        } else
        {
            Circulate();
        }
	}

    void Approach()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void BackUp()
    {
        transform.position += transform.forward * -1 * moveSpeed * Time.deltaTime;
    }

    void Circulate()
    {
        transform.position += transform.up * Mathf.Sin(Time.realtimeSinceStartup) * randomSpeed;
        transform.position += transform.right * Mathf.Cos(Time.realtimeSinceStartup) * randomSpeed;
    }
}
