using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class helpabout : MonoBehaviour {
	public static string code = "help";
	public SpriteRenderer ui;

	// Use this for initialization
	void Start () {
		if (code == "help") {
			ui.sprite = Resources.Load<Sprite> ("Sprites/UI/help");
		} else {
			ui.sprite = Resources.Load<Sprite> ("Sprites/UI/about");
		}
	}

	public void Back () {
		SceneManager.LoadScene ("MainMenu");
	}
}
