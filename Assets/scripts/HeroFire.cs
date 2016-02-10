using UnityEngine;
using System.Collections;

public class HeroFire : MonoBehaviour {
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		// autodestroys itself in 3 seconds
		Destroy(gameObject, 3);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag.Equals ("enemy")) {
			GameObject hitExplosion = Instantiate (explosion, transform.position, Quaternion.identity) as GameObject;
			int scale = Random.Range(1,5);
			hitExplosion.transform.position = gameObject.transform.position;
			hitExplosion.transform.localScale = new Vector3(scale,scale);
			Destroy (hitExplosion, 0.5f);
			Destroy (gameObject);
		}
	}

	
}
