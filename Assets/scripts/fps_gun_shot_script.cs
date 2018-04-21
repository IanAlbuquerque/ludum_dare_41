using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fps_gun_shot_script : MonoBehaviour {

	public AudioSource gunShotAudioSource;
	public AudioSource gunHitAudioSource;
	public KeyCode shotKeycode;

	public GameObject fpsCameraKnockbackFrame;
	public Camera fpsCamera;

	private int raycastTargetLayer;

	public fps_hits_control fpsHitsControlScript;

	private bool isKnockbackAnimationActive;
	private float knockbackAnimationStartTimestamp;

	public float knockbackAngle;
	public float knockbackAnimationDuration;

	// Use this for initialization
	void Start () {
		this.raycastTargetLayer = 1 << 8;
		this.isKnockbackAnimationActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(this.shotKeycode)) {
			this.onShotTrigger();
		}
		if (this.isKnockbackAnimationActive) {
			float t = (Time.time - this.knockbackAnimationStartTimestamp) / this.knockbackAnimationDuration;
			Debug.Log(t);
			this.fpsCameraKnockbackFrame.transform.eulerAngles = new Vector3((1-t) * (-this.knockbackAngle) + t * 0.0f,
																															0.0f,
																															0.0f);
			if (t > 1.0f) {
				this.fpsCameraKnockbackFrame.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
				this.isKnockbackAnimationActive = false;
			}
		}
	}

	void onShotTrigger() {
		RaycastHit hit;
		this.gunShotAudioSource.Play();
		this.runKnockbackAnimation();
		if (Physics.Raycast(this.fpsCamera.transform.position, this.fpsCamera.transform.forward, out hit, Mathf.Infinity, raycastTargetLayer)) {
			this.onTargetHit(hit);
		} else {
			this.onTargetMiss();
		}
	}

	void runKnockbackAnimation() {
		this.isKnockbackAnimationActive = true;
		this.knockbackAnimationStartTimestamp = Time.time;
		this.fpsCameraKnockbackFrame.transform.eulerAngles.Set(-this.knockbackAngle,
																														0.0f,
																														0.0f);
		}

	void onTargetHit(RaycastHit hit) {
		this.gunHitAudioSource.Play();
    this.fpsHitsControlScript.registerHit();
	}

	void onTargetMiss() {
    this.fpsHitsControlScript.registerMiss();
	}
}
