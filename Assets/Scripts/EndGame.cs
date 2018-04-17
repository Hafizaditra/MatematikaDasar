using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {
	public GameObject bubble;
	bool attackMe = false;
	public GameObject popUp;
	public GameObject love1;
	public GameObject love2;
	public GameObject love3;
	public Text score;
	public Text GameOver;
	public GameObject nyawaIn;

	void Start(){
		nyawaIn.SetActive (false);
		popUp.SetActive (false);
		love1.SetActive (true);
		love2.SetActive (true);
		love3.SetActive (true);
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			attackMe = true;
			bubble.SetActive (true);
		}
	}
	void OnTriggerStay2D (Collider2D other){
		if (other.tag == "Player") {
			attackMe = true;
		}
	}
	void OnTriggerExit2D (Collider2D other){
		if (other.tag == "Player") {
			attackMe = false;
			bubble.SetActive (false);
		}
	}

	void Update () {
		if (attackMe && CharacterBehaviour.attacking) {
			popUp.SetActive (true);
			score.text = QuessHandler.score.ToString ();
			GameOver.text = "Level Selesai!";
			if (QuessHandler.nyawa == 2) {
				love3.SetActive (false);
			}
			else if (QuessHandler.nyawa == 1) {
				love3.SetActive (false);
				love2.SetActive (false);
			}

			//highscoring
			int level = PlayerPrefs.GetInt ("PlayerLevel", 0);
			if (QuessHandler.score > PlayerPrefs.GetInt ("Level" + level.ToString () + "_highscore", 0)) {
				PlayerPrefs.SetInt ("Level" + level.ToString () + "_highscore", QuessHandler.score);
			}
			PlayerPrefs.SetInt ("Level" + (level + 1).ToString (), 1);
		}
	}

	public void Keluar () {
		SceneManager.LoadScene ("Level");
	}
}
