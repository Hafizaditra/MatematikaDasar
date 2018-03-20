using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour {
	public GameObject character;
	//walking
	bool walkingLeft = false;
	bool walkingRight = false;
	float speed = 5;
	bool faceLeft = true;
	public bool cameraFollow = false;

	//attack
	bool attacking = false;
	float attackTime = 1f;

	//jump
	int jumpCount = 0;
	
	// Update is called once per frame
	void Update () {
		if (cameraFollow) {
			Camera.main.transform.position = new Vector3 (character.transform.position.x, character.transform.position.y, Camera.main.transform.position.z);
		}

		if (character.GetComponent<Transform> ().rotation.y == 0) {
			faceLeft = true;
		} else {
			faceLeft = false;
		}


		if (walkingLeft) {
			character.transform.position = new Vector2 (character.transform.position.x + speed * Time.deltaTime, character.transform.position.y);
		} else if (walkingRight) {
			character.transform.position = new Vector2 (character.transform.position.x - speed * Time.deltaTime, character.transform.position.y);
		}

		if (attacking) {
			attackTime -= Time.deltaTime;
			if (attackTime <= 0) {
				attacking = false;
				character.GetComponent<Animator> ().SetBool ("Attack", false);
				attackTime = 1;
			}
		}

		if (character.GetComponent<GroundCollisionHandler>().onGround) {
			character.GetComponent<Animator> ().SetBool ("Jump", false);
		}

		if (character.GetComponent<GroundCollisionHandler> ().onGround) {
			jumpCount = 0;
		}
	}

	void FixedUpdate () {
		if (!character.GetComponent<GroundCollisionHandler> ().onGround) {
			if (character.GetComponent<Rigidbody2D> ().velocity.y < 0) {
				character.GetComponent<Rigidbody2D> ().gravityScale = 2.5f;
			}
		} else {
			character.GetComponent<Rigidbody2D> ().gravityScale = 1;
		}
	}

	public void LeftWalkDown () {
		character.GetComponent<Transform> ().rotation = new Quaternion (0, 0, 0, 0);
		character.GetComponent<Animator> ().SetBool ("Walking", true);
		walkingLeft = true;
		walkingRight = false;
	}
	public void RightWalkDown () {
		character.GetComponent<Transform> ().rotation = new Quaternion (0, 180, 0, 0);
		character.GetComponent<Animator> ().SetBool ("Walking", true);
		walkingRight = true;
		walkingLeft = false;
	}

	public void LeftWalkUp () {
		character.GetComponent<Animator> ().SetBool ("Walking", false);
		walkingLeft = false;
	}
	public void RightWalkup () {
		character.GetComponent<Animator> ().SetBool ("Walking", false);
		walkingRight = false;
	}
		
	public void Jump () {
		if (jumpCount < 2) {
			character.GetComponent<GroundCollisionHandler> ().onGround = false;
			character.GetComponent<Animator> ().SetBool ("Jump", true);
			character.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 200);
			jumpCount++;
		}
	}

	public void Attack () {
		attacking = true;
		character.GetComponent<Animator> ().SetBool ("Attack", true);
	}
}
