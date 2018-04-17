﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public GameObject popUp;

	public void Play () {
		SceneManager.LoadScene ("Level");
	}
	public void HelpAbout (string code) {
		helpabout.code = code;
		SceneManager.LoadScene ("HelpAbout");
	}
	public void Exit () {
		Application.Quit ();
	}
	public void ResetData (){
		popUp.SetActive (true);
	}
	public void No () {
		popUp.SetActive (false);
	}
	public void Yes () {
		PlayerPrefs.DeleteAll ();
		SceneManager.LoadScene ("Splash");
	}



	void Start () {
		popUp.SetActive (false);
	}
}