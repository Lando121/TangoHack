using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawns : MonoBehaviour {
    public float moveSpeed = 1;
    private float randomSpeed;
    private Vector3 startingPoint;

	// Use this for initialization
	void Start () {
        randomSpeed = Random.RandomRange(0.005f, 0.02f);
        startingPoint = transform.position;
    }   

    // Update is called once per frame
    void Update () {
        transform.LookAt(Camera.main.transform);
        //set x and z rotation to 0.
        float y = transform.rotation.eulerAngles.y;
        transform.rotation.eulerAngles.Set(0, y, 0);


        float distance = (startingPoint - transform.position).magnitude;

        if ( distance < 2 + randomSpeed * 10)
        {
            Approach();
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
