using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {
	public float speed = 15.0f;
	public GameObject projectile;
	public AudioClip fireSound;
	public float padding = 1f;
	public float projectileSpeed = 10;
	public float firingRate = 0.2f;
	public float health = 250f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = new Vector3();

		if(Input.GetKeyDown(KeyCode.Space)){
			InvokeRepeating("Fire", 0.0001f, firingRate);
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("Fire");
		}


		if (Input.GetKey (KeyCode.LeftArrow)) {
			//transform.position += Vector3.left * speed * Time.deltaTime;
			direction += Vector3.left;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			direction += Vector3.right; 
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			direction += Vector3.up; 
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			direction += Vector3.down; 
		}

// restrict the player to the gamespace
		float newX = Mathf.Clamp(direction.x, 0.5f, 20f);
		//transform.position = new Vector3(newX, direction.y, direction.z);
		transform.Translate (direction.normalized * speed * Time.deltaTime);
	}

	void Fire(){
		GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		//beam.rigidbody2D.velocity = new Vector3(0, projectileSpeed, 0);
		beam.rigidbody2D.velocity = Vector3.up * projectileSpeed;
		//AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}


}
