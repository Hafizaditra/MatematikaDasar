using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	public QuessHandler system;
	public bool isDead = false;
	public GameObject bubble;
	bool attackMe = false;
	public Sprite[] soal;
	public string[] jawaban;

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
		}
	}

	void Update () {
		if (!isDead) {
			if (attackMe) {
				if (system.setText) {
					system.startSoal = true;
					system.timer = 0;
					int index = Random.Range (0, soal.Length);
					system.soal.sprite = soal [index];
					system.jawaban = jawaban [index];
					system.setText = false;
				}
				if (CharacterBehaviour.attacking) {
					system.animate = this.gameObject;
					system.setText = true;
					system.isSoal = true;
					system.popUp.SetActive (true);
					CharacterBehaviour.attacking = false;
				}
			} else {
				bubble.SetActive (false);
			}
		} else {
			bubble.SetActive (false);
		}
	}
}
