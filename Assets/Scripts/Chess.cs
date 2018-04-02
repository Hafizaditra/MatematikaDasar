using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chess : MonoBehaviour {
	public QuessHandler system;
	public bool isOpen = false;
	public GameObject bubble;
	bool attackMe = false;
	public Sprite[] hint;
	public static int hintIndex = 0;

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			attackMe = true;
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
		if (!isOpen) {
			if (attackMe) {
				bubble.SetActive (true);
				system.animate = this.gameObject;
				system.setText = true;
				system.isSoal = false;
				if (system.setText) {
					if (hintIndex == hint.Length - 1) {
						system.nextHint.interactable = false;
					} else {
						system.nextHint.interactable = true;
					}
					if (hintIndex == 0) {
						system.prevHint.interactable = false;
					} else {
						system.prevHint.interactable = true;
					}
					system.soal.sprite = hint [hintIndex];
					system.setText = false;
				}
				if (CharacterBehaviour.attacking) {
					system.popUp.SetActive (true);
					this.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Place/Chess Castle/3") as Sprite;
				}
			} else {
				bubble.SetActive (false);
			}
		}
	}
}
