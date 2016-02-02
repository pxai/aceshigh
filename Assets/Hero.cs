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
		if(Input.GetKeyDown(KeyCode.Space)){
			InvokeRepeating("Fire", 0.0001f, firingRate);
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("Fire");
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.position += Vector3.left * speed * Time.deltaTime;
		}else if (Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right * speed * Time.deltaTime; 
		}
		
		// restrict the player to the gamespace
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}

	void Fire(){
		GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		//beam.rigidbody2D.velocity = new Vector3(0, projectileSpeed, 0);
		//AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}
}
