using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
	public GameObject explosion;
	public AudioClip[] explosions = new AudioClip[4];
	private int life = 3;

	// Use this for initialization
	void Start () {
		this.rigidbody2D.velocity = Vector3.down * 5;

		//Destroy(gameObject, 6);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag.Equals ("herofire")) {

			playRandom ();
			//Destroy (gameObject);
			life--;
			Debug.Log ("Hit! "  + life);


			if (life < 0) {
				Debug.Log("Ship destroyed!");
				audio.clip = explosions[1];
				//audio.PlayDelayed(0);
				audio.Play ();
				Destroy(gameObject);
			}
		}
	}

	void playRandom(){ // call this function to play a random sound
		if (audio.isPlaying) return; // don't play a new sound while the last hasn't finished
		//audio.clip = sounds[Random.Range(0,sounds.length)];
		audio.Play();
	}
}
