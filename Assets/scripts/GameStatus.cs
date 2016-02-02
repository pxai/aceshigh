using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameStatus : MonoBehaviour {

	public static int points = 0;
	public static int maxHits = 5;
	public Text maxHitsText;
	public Slider sliderMaxHits;

	// Use this for initialization
	void Start () {
		points = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeMaxHits () {
		maxHits = (int)sliderMaxHits.value;
		maxHitsText.text = maxHits + "";
		Debug.Log ("Modificado a " + maxHits);
	}
}
