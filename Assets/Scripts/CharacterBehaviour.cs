using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterBehaviour : MonoBehaviour {
	public List<GameObject> characters = new List<GameObject>();
	public GameObject character;

	void Awake () {
		Time.timeScale = 1;
		int index = PlayerPrefs.GetInt ("PlayedChara", 1) - 1;
		character = characters [index];
		character.SetActive (true);
	}
	//walking
	bool walkingLeft = false;
	bool walkingRight = false;
	float speed = 7;
	bool faceLeft = true;
	public bool cameraFollow = false;

	//attack
	public static bool attacking = false;
	public static float attackTime = 1f;
	public static bool isHurt = false;
	public static float hurtTime = 1f;

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
			character.GetComponent<Animator> ().SetBool ("Attack", true);
			attackTime -= Time.deltaTime;
			if (attackTime <= 0) {
				attacking = false;
			}
		} else {
			character.GetComponent<Animator> ().SetBool ("Attack", false);
			attackTime = 1;			
		}

		if (isHurt) {
			character.GetComponent<Animator> ().SetBool ("Hurt", true);
			hurtTime -= Time.deltaTime;
			if (hurtTime <= 0) {
				isHurt = false;
			}
		} else {
			character.GetComponent<Animator> ().SetBool ("Hurt", false);
			hurtTime = 1;
		}


		if (character.GetComponent<GroundCollisionHandler>().onGround) {
			character.GetComponent<Animator> ().SetBool ("Jump", false);
		}

		if (character.GetComponent<GroundCollisionHandler> ().onGround) {
			jumpCount = 0;
		}

		if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1) {
			Time.timeScale = 0;
			canvasPause.SetActive (true);
		}
		else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0) {
			Time.timeScale = 1;
			canvasPause.SetActive (false);
		}
	}

	void FixedUpdate () {
		if (!character.GetComponent<GroundCollisionHandler> ().onGround) {
			if (character.GetComponent<Rigidbody2D> ().velocity.y < 0) {
				character.GetComponent<Rigidbody2D> ().gravityScale = 3.5f;
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
	}

	[Header("Gameplay")]
	public GameObject canvasPause;

	public void Pause () {
		Time.timeScale = 0;
		canvasPause.SetActive (true);
	}

	public void Resume () {
		Time.timeScale = 1;
		canvasPause.SetActive (false);
	}

	public void Exit () {
		SceneManager.LoadScene ("MainMenu");
	}
}
