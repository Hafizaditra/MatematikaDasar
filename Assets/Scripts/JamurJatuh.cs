using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamurJatuh : MonoBehaviour {
	bool jatuh = false;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			jatuh = true;
			for (int i = 0; i < this.transform.childCount; i++) {
				this.transform.GetChild (i).gameObject.GetComponent<Rigidbody2D> ().gravityScale = 1;
			}
		}
	}

	void FixedUpdate () {
		if (jatuh) {
			for (int i = 0; i < this.transform.childCount; i++) {
				if (this.transform.GetChild (i).gameObject.GetComponent<GroundCollisionHandler> ().onGround) {
					this.transform.GetChild (i).gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
					this.transform.GetChild (i).gameObject.GetComponent<CircleCollider2D> ().isTrigger = true;
					this.transform.GetChild (i).gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 9;
					this.transform.GetChild (i).gameObject.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
				}
			}
		}
	}
}
