using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fps_hits_control : MonoBehaviour {

	public fps_resource_script fpsResourceScript;

	public Text hitPopupText;

	public float fGainPercentageOnHit;
	public Text hitsText;
	public Text missesText;
	private int numHits;
	private int numMisses;

	private bool isHitPopupRunning;
	private float currentPopupDuration;

	public float hitPopupAnimationDuration;
	public float hitPopupAnimationDistance;

	// Use this for initialization
	void Start () {
		this.numHits = 0;
		this.numMisses = 0;
		this.updateHitsAndMissesText();
		this.hitPopupText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.isHitPopupRunning) {
			this.currentPopupDuration += Time.deltaTime;
			Vector4 color = this.hitPopupText.color;
			color.w = 1.0f - this.currentPopupDuration / this.hitPopupAnimationDuration;
			this.hitPopupText.color = color;
			this.hitPopupText.transform.localPosition = new Vector3(0.0f, this.currentPopupDuration / this.hitPopupAnimationDuration * this.hitPopupAnimationDistance, 0.0f);
			if (this.currentPopupDuration > this.hitPopupAnimationDuration) {
				this.isHitPopupRunning = false;
				this.hitPopupText.enabled = false;
			}
		}
	}

	void updateHitsAndMissesText() {
		this.hitsText.text = "HITS = " + this.numHits.ToString();
		this.missesText.text = "MISSES = " + this.numMisses.ToString();
	}

	public void registerHit() {
		this.numHits += 1;
		float newFrootsValue = Mathf.Floor(this.fpsResourceScript.getCurrentF() * this.fGainPercentageOnHit);
		this.fpsResourceScript.addToCurrentF(newFrootsValue);
		this.updateHitsAndMissesText();
		this.hitPopupText.text = "+ " + newFrootsValue + " FROOTS!"; 
		this.isHitPopupRunning = true;
		this.hitPopupText.enabled = true;
		this.currentPopupDuration = 0.0f;
		this.hitPopupText.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
	}

	public void registerMiss() {
		this.numMisses += 1;
		this.updateHitsAndMissesText();
	}
}
