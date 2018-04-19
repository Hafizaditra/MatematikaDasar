using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharaterSelect : MonoBehaviour {
	public void Back () {
		SceneManager.LoadScene ("Level");
	}

	public void SelectCharacter (int code) {
		PlayerPrefs.SetInt ("PlayedChara", code);
		SceneManager.LoadScene ("Level");
	}
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadScene ("Level");
		}
	}
}
