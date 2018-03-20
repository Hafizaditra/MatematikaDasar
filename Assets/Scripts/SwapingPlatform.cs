using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapingPlatform : MonoBehaviour {
	bool swaping = true;
	float swapTime = 1;
	float currentTime = 0;


	void Update () {
		if (swaping) {
			currentTime += Time.deltaTime;
			if (currentTime >= swapTime) {
				this.transform.localScale = new Vector3 (this.transform.localScale.x, Random.Range (2, 4), this.transform.localScale.z);
				swapTime = Random.Range (0.2f, 1);
				currentTime = 0;
			}
		}
	}
}
