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
	private bool multifire = false;


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
			//Invokes the method methodName in time seconds, 
			//then repeatedly every repeatRate seconds.
			InvokeRepeating("Fire", 0.0001f, firingRate);
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("Fire");
		}


		if (Input.GetKey (KeyCode.LeftArrow)) {
			direction += Vector3.left;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			direction += Vector3.right; 
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			direction += Vector3.up; 
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			direction += Vector3.down; 

		}

		// restrict the player to the gamespace
		float newX = Mathf.Clamp(transform.position.x, 0.5f, 16f);
		float newY = Mathf.Clamp(transform.position.y, 0f, 10f);
		transform.position = new Vector3(newX, newY, direction.z);
		transform.Translate (direction.normalized * speed * Time.deltaTime);
	}

	void Fire(){
		if (status != FLYING_STATUS) { return;}

		if (multifire) {
			GameObject beam1 = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
			GameObject beam2 = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
			GameObject beam3 = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
			beam1.GetComponent<Rigidbody2D>().velocity = Vector3.up * projectileSpeed;
			beam2.GetComponent<Rigidbody2D>().velocity = new Vector3(-0.2f,1,0) * projectileSpeed;
			beam3.GetComponent<Rigidbody2D>().velocity = new Vector3(0.2f,1,0) * projectileSpeed;

		} else {
			GameObject beam = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
			beam.GetComponent<Rigidbody2D>().velocity = Vector3.up * projectileSpeed;
		}

	}


	public void setMultifire () {
		Debug.Log ("Got multifire!!");
		multifire = true;
	}

	void OnTriggerEnter2D (Collider2D collider) {
		//return;
		if (collider.gameObject.tag.Equals ("enemyfire") 
		    	&& status == FLYING_STATUS) {
			heroAnimator.SetBool("Dead",true);
			status = SPAWN_STATUS;
			GetComponent<AudioSource>().Play ();
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
			gameStatus.respawn (gameObject.transform.position);
		} else {
			Debug.Log("Game Over");
			Application.LoadLevel("GameOver");
		}

	}
}
