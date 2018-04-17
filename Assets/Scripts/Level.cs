using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour {
	public int level = 0;
	public string deskripsi;
	public GameObject PopUP;
	public Text leveltext;
	public Text deskripsitext;
	public Text highscoretext;

	void Start () {
		if (level == 1) {
			PlayerPrefs.SetInt ("Level1", 1);
		}

		if (PlayerPrefs.GetInt ("Level" + level.ToString (), 0) == 1) {
			this.GetComponent<Button> ().interactable = true;
		}
	}

	public void SelectLevel () {
		LevelMenu.levelIndex = level;
		leveltext.text = "Level " + level.ToString ();
		deskripsitext.text = deskripsi;
		highscoretext.text = PlayerPrefs.GetInt ("Level" + level.ToString () + "_highscore", 0).ToString ();
		PopUP.SetActive (true);
	}
}
