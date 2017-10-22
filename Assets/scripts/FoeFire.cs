using UnityEngine;
using System.Collections;

public class FoeFire : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.name =="hero") {
			GetComponent<AudioSource>().Play();
			Debug.Log ("Hero Hit!");
			Destroy(collider.gameObject);
		}
	}
}
