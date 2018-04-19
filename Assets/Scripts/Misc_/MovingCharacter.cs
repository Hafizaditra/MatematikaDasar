using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCharacter : MonoBehaviour {
	bool moving = true;
	int dir = 0;
	float swapTime = 2;
	float currentTime = 0;



	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			other.gameObject.transform.parent = this.transform;
		}
	}
	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Player") {
			other.gameObject.transform.parent = null;
		}
	}

	void Update () {
		if (moving) {
			if (dir == 0) {
				this.transform.rotation = new Quaternion (0, 0, 0, 0);
				this.transform.position += new Vector3 (1, 0, 0) * Time.deltaTime;
			} else {
				this.transform.rotation = new Quaternion (0, 180, 0, 0);
				this.transform.position -= new Vector3 (1, 0, 0) * Time.deltaTime;
			}

			currentTime += Time.deltaTime;
			if (currentTime > swapTime && dir == 0) {
				dir = 1;
				currentTime = 0;
			}
			if (currentTime > swapTime && dir == 1) {
				dir = 0;
				currentTime = 0;
			}
		}
	}
}
