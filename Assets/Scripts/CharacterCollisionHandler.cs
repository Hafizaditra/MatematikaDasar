using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisionHandler : MonoBehaviour {
	public bool onGround = false;

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "Ground") {
			onGround = true;
		}
	}
	void OnCollisionExit2D (Collision2D other){
		if (other.gameObject.tag == "Ground") {
			onGround = false;
		}
	}
}
