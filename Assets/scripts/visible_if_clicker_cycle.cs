using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class visible_if_clicker_cycle : MonoBehaviour {

	public fps_clickers_script fpsClickersScript;
	public RawImage img;

	public int clickerIndex;

	public float minDuration;
	private float currentDuration;
	private bool isShown;

	private float currentClickDuration;

	public AudioSource clickSound;

	// Use this for initialization
	void Start () {
		this.img.enabled = false;
		this.isShown = false;
		this.currentClickDuration = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.isShown) {
			this.currentDuration += Time.deltaTime;
			if (this.currentDuration > this.minDuration) {
				this.img.enabled = false;
				// this.isShown = false;
			}
			if (this.currentDuration > (this.minDuration + 0.05f)) {
				// this.img.enabled = false;
				this.isShown = false;
			}
		}

		this.currentClickDuration += Time.deltaTime;
		if (this.isShown == false && this.currentClickDuration >= 1.0f / (this.fpsClickersScript.getFPS(this.clickerIndex) * this.fpsClickersScript.getCount(this.clickerIndex))) {
			this.currentClickDuration = 0.0f;
			this.isShown = true;
			this.img.enabled = true;
			this.currentDuration = 0.0f;
			this.clickSound.Play();
		}
	}
}
