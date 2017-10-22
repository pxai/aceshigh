using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
	public GameObject explosion;

	public GameObject projectile;
	public AudioClip[] explosions = new AudioClip[4];
	private int life = 3;
	private float fireRate = 0.3f;

	// Use this for initialization
	void Start () {
		// Avoid to add "(Clone)" to dynamically generated objects
		name = name.Replace("(Clone)", "");
		this.GetComponent<Rigidbody2D>().velocity = Vector3.down * 3;
	}
	
	// Update is called once per frame
	void Update () {

		float limit = fireRate * Time.deltaTime;
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
				GetComponent<AudioSource>().Play ();
				Destroy(gameObject);
			}
		}
	}

	void fire () {
		Vector3 position = transform.position;
		position.z = 0;
		GameObject beam = Instantiate(projectile, position, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = Vector3.down * 10;
	}

	void playRandom(){ // call this function to play a random sound
		if (GetComponent<AudioSource>().isPlaying) return; // don't play a new sound while the last hasn't finished

		AudioSource.PlayClipAtPoint (explosions [Random.Range (0, explosions.Length - 1)], transform.position);
	}


}
