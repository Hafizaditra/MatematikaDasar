using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuessHandler : MonoBehaviour {
	public GameObject popUp;
	public Image soal;
	public bool setText = false;
	public bool isSoal = false;
	public GameObject soalButtons;
	public GameObject hintButtons;
	public string jawaban;
	public GameObject animate;
	public Button nextHint;
	public Button prevHint;
	bool isCorrect = false;
	bool answered = false;

	bool attacking = true;
	float attackTime = 1;

	//Scoring
	public bool startSoal = false;
	public float timer = 0;
	public float maxBintang3 = 10;
	public float maxBintang2 = 20;
	public int score;
	public Text scoreText;

	//Hearts
	public Image heart1;
	public Image heart2;
	public Image heart3;
	int nyawa = 3;

	void Start () {
		nyawa = 3;
		score = 0;
		scoreText.text = "0";
		popUp.SetActive (false);
	}

	void Update () {
		//scoring
		scoreText.text = score.ToString ();
		if (nyawa == 2) {
			heart3.sprite = Resources.Load<Sprite> ("Sprites/UI/nyawa") as Sprite;
		} else if (nyawa == 1) { 
			heart2.sprite = Resources.Load<Sprite> ("Sprites/UI/nyawa") as Sprite;
		} else if (nyawa == 0) {
			heart1.sprite = Resources.Load<Sprite> ("Sprites/UI/nyawa") as Sprite;
		}



		if (isSoal) {
			soalButtons.SetActive (true);
			hintButtons.SetActive (false);
		} else {
			soalButtons.SetActive (false);
			hintButtons.SetActive (true);
		}

		if (startSoal) {
			timer += Time.deltaTime;
		}

		if (answered) {
			startSoal = false;
			if (isCorrect) {
				CharacterBehaviour.attacking = true;
				CharacterBehaviour.attackTime = 1;
				animate.GetComponent<Animator> ().SetBool ("Dead", true);
				animate.GetComponent<EnemyBehaviour> ().isDead = true;

				if (timer <= maxBintang3) {
					score += 20;
				} else if (timer > maxBintang3 && timer <= maxBintang2) {
					score += 15;
				} else if (timer > maxBintang2) {
					score += 10;
				}

				answered = false;
			} else {
				CharacterBehaviour.isHurt = true;
				CharacterBehaviour.hurtTime = 1;
				attacking = true;
				if (nyawa >= 1) {
					nyawa--;
				}
				answered = false;
			}
		}

		if (attacking) {
			animate.GetComponent<Animator> ().SetBool ("Attack", true);
			attackTime -= Time.deltaTime;
			if (attackTime <= 0) {
				attacking = false;
			}
		} else {
			animate.GetComponent<Animator> ().SetBool ("Attack", false);
			attackTime = 1;
		}
	}


	public void NextHint () {
		Chess.hintIndex++;
		setText = true;
	}
	public void PrevHint () {
		Chess.hintIndex--;
		setText = true;
	}

	public void KeluarHint () {
		CharacterBehaviour.attacking = false;
		Chess.hintIndex = 0;
		popUp.SetActive (false);
	}

	public void JawabA () {
		if (jawaban == "A") {
			isCorrect = true;
		} else {
			isCorrect = false;
		}
		popUp.SetActive (false);
		answered = true;
	}
	public void JawabB () {
		if (jawaban == "B") {
			isCorrect = true;
		} else {
			isCorrect = false;
		}
		popUp.SetActive (false);
		answered = true;
	}
	public void JawabC () {
		if (jawaban == "C") {
			isCorrect = true;
		} else {
			isCorrect = false;
		}
		popUp.SetActive (false);
		answered = true;
	}
	public void JawabD () {
		if (jawaban == "D") {
			isCorrect = true;
		} else {
			isCorrect = false;
		}
		popUp.SetActive (false);
		answered = true;
	}
}
