using UnityEngine;
using System.Collections;

public class GreyFoe : MonoBehaviour {
	public GameObject explosion;
	public GameObject projectile;
	private int projectileSpeed = 10;
	private float foeFireRate = 0.9f;
	
	// Use this for initialization
	void Start () {
		this.rigidbody2D.velocity = Vector3.down * 5;
		fire ();
		// In 6 sec the ship will be autodestroyed
		Destroy(gameObject,3);
	}
	
	// Update is called once per frame
	void Update () {
		float limit = foeFireRate * Time.deltaTime;
		if (Random.value < limit) {
			fire ();
			
		}
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag.Equals ("herofire")) {
				Debug.Log("Plane destroyed!");
				audio.Play ();
				Destroy(gameObject);
		}
	}
	

	void fire(){
		GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		beam.rigidbody2D.velocity = Vector3.down * projectileSpeed;
	}
}
