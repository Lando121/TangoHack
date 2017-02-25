using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPoint : MonoBehaviour {

    public GameObject wallSpawns;
    public int spawnTime;
    public int maxObjects;
    public int currObject = 0;


    private List<GameObject> spawns;
    private float time = 0f;

	// Use this for initialization
	void Start () {
        spawns = new List<GameObject>(maxObjects);
	}
	
	// Update is called once per frame
	void Update () {
        if (currObject < maxObjects)
        {
            time += Time.deltaTime;
            if (time > spawnTime)
            {
                GameObject spawn = Instantiate(wallSpawns);
                
                spawn.transform.position = this.transform.position;

                spawns.Add(spawn);
                time = 0;
                currObject++;
            }
        }
	}
}
