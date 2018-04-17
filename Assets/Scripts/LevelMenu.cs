using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour {
	public GameObject popup;
	public static int levelIndex = 0;
	public Image karakter;

	void Start (){
		popup.SetActive (false);
		karakter.sprite = Resources.Load<Sprite> ("Sprites/UI/karakter" + PlayerPrefs.GetInt ("PlayedChara", 1));
	}

	public void Back () {
		SceneManager.LoadScene ("MainMenu");
	}

	public void ClosePopUp () {
		popup.SetActive(false);
	}
	public void Play () {
		PlayerPrefs.SetInt ("PlayerLevel", levelIndex);
		SceneManager.LoadScene ("Level" + levelIndex.ToString ());
	}

	public void Character () {
		SceneManager.LoadScene ("Characters");
	}
}
