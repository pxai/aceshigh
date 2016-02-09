using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameStatus : MonoBehaviour {

	public static int points = 0;
	public static int maxHits = 5;
	public Text maxHitsText;
	public Slider sliderMaxHits;
	public GameObject hero;

	// Use this for initialization
	void Start () {
		points = 0;
		spawnHero (new Vector3(5,1));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeMaxHits () {
		maxHits = (int)sliderMaxHits.value;
		maxHitsText.text = maxHits + "";
		Debug.Log ("Modificado a " + maxHits);
	}

	public void spawnHero (Vector3 position) {
		GameObject freshHero = Instantiate (hero, position, Quaternion.identity) as GameObject;

	}
}
