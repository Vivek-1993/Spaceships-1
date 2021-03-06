﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackSpawn : MonoBehaviour {

    public GameObject healthPack;
    public GameObject spaceship;
    private float timeStamp;
    private float spawnCooldown = 30f; // In Seconds

    void SpawnHealthPack()
    {
        GameObject health = GameObject.Instantiate(healthPack, new Vector3(Random.Range((spaceship.transform.position.x) - 20.0f, (spaceship.transform.position.x) + 20.0f), spaceship.transform.position.y, Random.Range((spaceship.transform.position.z) - 20.0f, (spaceship.transform.position.z) + 20.0f)), transform.rotation) as GameObject;
    }

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (timeStamp <= Time.time)
        {
            SpawnHealthPack();
            timeStamp = Time.time + spawnCooldown;
        }
    }
}
