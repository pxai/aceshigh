﻿using UnityEngine;
using System.Collections;

public class Submarine : MonoBehaviour {
	public GameObject projectile;
	private int projectileSpeed = 5;

	// Use this for initialization
	void Start () {
		Invoke ("fire", 1);
		Destroy (gameObject, 2.5f);
	}

	void fire(){
		Hero hero = GameObject.FindObjectOfType (typeof(Hero)) as Hero;
		
		GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		Vector3 toTarget = hero.GetComponent<Rigidbody2D>().position - transform.GetComponent<Rigidbody2D>().position ;
		
		beam.GetComponent<Rigidbody2D>().velocity = toTarget * projectileSpeed;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
