using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
	public GameObject explosion;
	private int life = 3;
	public GameObject projectile;
	private int projectileSpeed = 8;
	private float foeFireRate = 0.4f;

	// Use this for initialization
	void Start () {
		fire ();
		// In 6 sec the ship will be autodestroyed
		Destroy(gameObject,10);
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
			playRandom ();
			life--;
			Debug.Log ("Hit! "  + life);

			if (life < 0) {
				Debug.Log("Ship destroyed!");
				audio.Play ();
				Destroy(gameObject);
			}
		}
	}

	void playRandom(){ // call this function to play a random sound
		if (audio.isPlaying) return; // don't play a new sound while the last hasn't finished

		audio.Play();
	}

	void fire(){
		GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		beam.rigidbody2D.velocity = Vector3.down * projectileSpeed;
	}
}
