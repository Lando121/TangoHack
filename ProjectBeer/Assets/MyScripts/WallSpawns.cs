using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawns : MonoBehaviour {
    public float moveSpeed = 1;
    private float randomSpeed;
    private Vector3 startingPoint;
    private Vector3 startingRotation;
    private Transform start;


	// Use this for initialization
	void Start () {
        randomSpeed = Random.Range(0.005f, 0.02f);
        start = GameObject.Find("UIController").GetComponent<PlacingObjectController>().m_object.transform;
        startingPoint = transform.position;
        startingRotation = transform.rotation.eulerAngles;

    }   

    // Update is called once per frame
    void Update () {
        Debug.Log(start.forward);
        transform.rotation.eulerAngles.Set(startingRotation.x, startingRotation.y, startingRotation.z);
        transform.LookAt(Camera.main.transform);
        //set x and z rotation to 0.
        float y = transform.rotation.eulerAngles.y;
        transform.rotation.eulerAngles.Set(0, y, 0);
        float distance = (startingPoint - transform.position).magnitude;

        if ( distance < 0.2 + randomSpeed * 10)
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
        transform.position += start.forward * moveSpeed * Time.deltaTime;
    }

    void BackUp()
    {
        transform.position += transform.forward * -1 * moveSpeed * Time.deltaTime;
    }

    void Circulate()
    {
       // Debug.Log(start.forward);
        transform.position += start.up * Mathf.Sin(Time.realtimeSinceStartup) * randomSpeed;
        transform.position += start.right * Mathf.Cos(Time.realtimeSinceStartup) * randomSpeed;
    }
}
