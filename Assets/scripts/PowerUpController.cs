using UnityEngine;
using System.Collections;

public class PowerUpController : MonoBehaviour {
	public GameObject[] powerUps;
	private float powerUpsPerSecond = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float limit = powerUpsPerSecond * Time.deltaTime;
		if (Random.value < limit) {
			spawnPowerUp ();
		}
	}

	void spawnPowerUp () {
		GameObject randomPowerUp = powerUps [Random.Range (0, powerUps.Length)];
		GameObject freshPowerUp = Instantiate(randomPowerUp, transform.position, Quaternion.identity) as GameObject;
		
		freshPowerUp.transform.position = new Vector3 (Random.Range (1,10f),15f,2);
		freshPowerUp.rigidbody2D.velocity = Vector3.down * 2;
		Destroy (freshPowerUp,10);
	}
}
