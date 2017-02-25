﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawns : MonoBehaviour {
    public float moveSpeed = 1;

	// Use this for initialization
	void Start () {
    }   

// Update is called once per frame
void Update () {
       
        transform.LookAt(Camera.main.transform);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
	}
}