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
	public int status = 0; // 0: spawn, 1: fly, 2: dead
	public static int SPAWN_STATUS = 0;
	public static int FLYING_STATUS = 1;
	public static int DEAD_STATUS = 2;

	public static int lifes = 3;
	private Animator heroAnimator;


	// Use this for initialization
	void Start () {
		lifes = 3;
		heroAnimator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (heroAnimator.GetCurrentAnimatorStateInfo(0).IsName("Flying")) {
			status = FLYING_STATUS;
		}

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
		beam.rigidbody2D.velocity = Vector3.up * projectileSpeed;

	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag.Equals ("enemyfire") 
		    	&& status == FLYING_STATUS) {
			heroAnimator.SetBool("Dead",true);
			audio.Play ();
			Debug.Log ("Hit! ");
			lifes--;
			respawn ();
		}
	}

	void respawn () {
		Debug.Log ("Respawn. Total life: " + lifes);
		if (lifes > 0) {
			Destroy (gameObject, 2);
			heroAnimator.SetBool ("Dead", true);
			GameStatus gameStatus = GameObject.FindObjectOfType (typeof(GameStatus)) as GameStatus;
			gameStatus.spawnHero (gameObject.transform.position);
		} else {
			Debug.Log("Game Over");
			Application.LoadLevel("GameOver");
		}

	}
}
