using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Splash : MonoBehaviour {
	public Slider loading;
	public bool animateLogoFinish = false;

	// Use this for initialization
	void Start () {
		animateLogoFinish = false;
		loading.gameObject.SetActive (false);
		loading.value = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (animateLogoFinish && loading.value <= 1) {
			loading.gameObject.SetActive (true);
			loading.value += Time.deltaTime;
		}
		if (loading.value >= 1) {
			SceneManager.LoadScene ("MainMenu");
		}
	}

	public void FinishAnimate (){
		animateLogoFinish = true;
	}
}
