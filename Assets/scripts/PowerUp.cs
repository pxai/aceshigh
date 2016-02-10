using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {
	public GameObject explosion;
	public AudioClip powerupAudio;

	void Start () {
		// Avoid to add "(Clone)" to dynamically generated objects
		name = name.Replace("(Clone)", "");
	}

	void OnTriggerEnter2D (Collider2D collider) {

		if (collider.gameObject.tag.Equals ("Player")) {
			AudioSource.PlayClipAtPoint(powerupAudio, transform.position);
			Debug.Log ("Power up!!" + gameObject.name);
			switch (gameObject.name) {
			case "powerup1" : powerUp1Action();
				break;
			case "powerup2" : powerUp2Action();
				break;
			default:
				break;
			}
				
				Destroy(gameObject);
		}
	}

	void powerUp1Action () {
		Hero hero = GameObject.FindObjectOfType(typeof(Hero)) as Hero;
		hero.setMultifire ();
	}

	void powerUp2Action () {
		//GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
		Debug.Log ("Enemies: " + enemies.Length);
		foreach (GameObject enemy in enemies) {
			Debug.Log ("Destroying enemy");
			GameObject freshExplosion = Instantiate(explosion, enemy.transform.position,  Quaternion.identity) as GameObject;
			Destroy (freshExplosion, 1f);
			Destroy (enemy, 0.1f);
		}
	}
}
