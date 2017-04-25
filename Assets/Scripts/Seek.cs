﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour {

    public GameObject target;
    public int max_velocity;

    private Vector3 velocity;
    private Vector3 force;
    private Vector3 displacement;
    private Vector3 scale_displacement;
    private Vector3 new_force;

    // Use this for initialization
    void Start () {
        velocity = new Vector3(0, 0, 0);
        force = new Vector3(0, 0, 0);	
	}
	
	// Update is called once per frame
	void Update () {
        displacement = target.transform.position - transform.position;
        scale_displacement = displacement.normalized * max_velocity;
        new_force = scale_displacement - velocity;
        force = new_force;
        velocity += (force * Time.deltaTime);
        if (velocity.magnitude > max_velocity)
            velocity = velocity.normalized * max_velocity;
        transform.position += (velocity * Time.deltaTime);
    }
}
