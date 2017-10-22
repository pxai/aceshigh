using UnityEngine;
using System.Collections;

public class GreyFoe : MonoBehaviour {
	public GameObject explosion;
	public GameObject projectile;
	private float projectileSpeed = 5f;
	private float foeFireRate = 0.1f;
	private Animator greyFoeAnimator;

	// Use this for initialization
	void Start () {
		// Avoid to add "(Clone)" to dynamically generated objects
		name = name.Replace("(Clone)", "");
		greyFoeAnimator = this.GetComponent<Animator>();
		this.GetComponent<Rigidbody2D>().velocity = Vector3.down * 5;
		// In 8 sec the ship will be autodestroyed
		Destroy(gameObject,8);
		Invoke("turnAround", Random.Range (2,4));

	}
	
	// Update is called once per frame
	void Update () {
		float limit = foeFireRate * Time.deltaTime;
		if (Random.value < limit) {
			fire ();
		}
	}


	void turnAround () {
		Debug.Log ("Turning around");
		greyFoeAnimator.SetBool("Turn",true);
		this.GetComponent<Rigidbody2D>().velocity = Vector3.up * 5;
		fire ();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag.Equals ("herofire")) {
				Debug.Log("Plane destroyed!");
				Destroy(gameObject);
		}
	}
	

	void fire(){
		Hero hero = GameObject.FindObjectOfType (typeof(Hero)) as Hero;

		GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		Vector3 toTarget = hero.GetComponent<Rigidbody2D>().position - transform.GetComponent<Rigidbody2D>().position ;

		beam.GetComponent<Rigidbody2D>().velocity = toTarget.normalized * projectileSpeed;
	}
}
