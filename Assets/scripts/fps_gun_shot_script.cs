using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fps_gun_shot_script : MonoBehaviour {

	public KeyCode shotKeycode;
	public Camera fpsCamera;

	private int raycastTargetLayer;

	// Use this for initialization
	void Start () {
		this.raycastTargetLayer = 1 << 8;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(this.shotKeycode)) {
			this.onShotTrigger();
		}
	}

	void onShotTrigger() {
		RaycastHit hit;
		if (Physics.Raycast(this.fpsCamera.transform.position, this.fpsCamera.transform.forward, out hit, Mathf.Infinity, raycastTargetLayer)) {
			this.onTargetHit(hit);
		} else {
			this.onTargetMiss();
		}
	}

	void onTargetHit(RaycastHit hit) {
    Debug.DrawRay(this.fpsCamera.transform.position, this.fpsCamera.transform.forward * hit.distance, Color.yellow);
		Debug.Log("Did Hit");
	}

	void onTargetMiss() {
    Debug.DrawRay(this.fpsCamera.transform.position, this.fpsCamera.transform.forward * 1000, Color.white);
		Debug.Log("Did NOT Hit");
	}
}
