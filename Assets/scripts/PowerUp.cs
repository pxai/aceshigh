using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {
	public GameObject explosion;

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag.Equals ("Player")) {
			Debug.Log ("Power up!!" + gameObject.name);
			switch (gameObject.name) {
			case "powerup1" : powerUp2Action();
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

	}

	void powerUp2Action () {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
		foreach (GameObject enemy in enemies) {
			Debug.Log ("Destroying enemy");
			Instantiate(explosion, enemy.transform.position, enemy.transform.rotation);
			Destroy (enemy);
		}
	}
}
