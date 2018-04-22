using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class visible_if_key_pressed : MonoBehaviour {

	public KeyCode keyCode;
	public RawImage img;

	public float minDuration;
	private float currentDuration;
	private bool isShown;

	public GameObject spaceButtonObj;


	// Use this for initialization
	void Start () {
		this.img.enabled = false;
		this.isShown = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(this.keyCode)) {
			Debug.Log("keydown");
			this.img.enabled = true;
			this.isShown = true;
			this.currentDuration = 0;
			this.spaceButtonObj.transform.localPosition = new Vector3(0.0f, 0.0f, -0.1f);
		}

		if (this.isShown) {
			this.currentDuration += Time.deltaTime;
			if (this.currentDuration > this.minDuration) {
				this.img.enabled = false;
				this.isShown = false;
				this.spaceButtonObj.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
			}
		}
	}
}
