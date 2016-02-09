using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
	public GameObject ship;
	private float shipPerSecond = 0.5f;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float limit = shipPerSecond * Time.deltaTime;
		if (Random.value < limit) {
			spawnShip ();
		}
	}
	
	private void spawnShip() {
		GameObject freshship = Instantiate(ship, transform.position, Quaternion.identity) as GameObject;

		freshship.transform.position = new Vector3 (Random.Range (1,10f),15f,2);
		freshship.rigidbody2D.velocity = Vector3.down * 3;
		
	}
}
