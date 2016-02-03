using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.rigidbody2D.velocity = Vector3.down * 5;
		
		// Make the enemy rotate on itself
		//this.rigidbody2D.angularVelocity = Random.Range(-200, 200);

		Destroy(gameObject, 6);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
