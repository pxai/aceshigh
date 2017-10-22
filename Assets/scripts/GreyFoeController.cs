using UnityEngine;
using System.Collections;

public class GreyFoeController : MonoBehaviour {
	public GameObject greyFoe;
	private float greyFoePerSecond = 0.5f;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float limit = greyFoePerSecond * Time.deltaTime;
		if (Random.value < limit) {
			spawnGreyFoe ();
		}
	}
	
	private void spawnGreyFoe() {
		GameObject freshGreyFoe = Instantiate(greyFoe, transform.position, Quaternion.identity) as GameObject;
		
		freshGreyFoe.transform.position = new Vector3 (Random.Range (1,10f),15f,2);
		freshGreyFoe.GetComponent<Rigidbody2D>().velocity = Vector3.down * 5;
		
	}
}
