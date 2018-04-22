using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class visible_if_button_pressed : MonoBehaviour {

	public Button btn;
	public RawImage img;

	public float minDuration;
	private float currentDuration;
	private bool isShown;

	// Use this for initialization
	void Start () {
		this.img.enabled = false;
		this.isShown = false;
		this.btn.onClick.AddListener(onBtnClick);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.isShown) {
			this.currentDuration += Time.deltaTime;
			if (this.currentDuration > this.minDuration) {
				this.img.enabled = false;
				this.isShown = false;
			}
		}
	}

	void onBtnClick() {
		this.img.enabled = true;
		this.isShown = true;
		this.currentDuration = 0;
	}
}
