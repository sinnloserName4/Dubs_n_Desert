using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class highscortext : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("Score")) {
			gameObject.GetComponent<Text> ().text = PlayerPrefs.GetInt ("Score").ToString();
		}
		else gameObject.GetComponent<Text> ().text = "nix hier :P";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
