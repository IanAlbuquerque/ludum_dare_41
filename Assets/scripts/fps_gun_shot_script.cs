using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fps_gun_shot_script : MonoBehaviour {

	public SpriteRenderer gunHitSpriteRender;

	private bool isHitMarkAnimationActive;
	private float hitMarkAnimationStartTimestamp;
	public float hitMarkAnimationDuration;


	public AudioSource gunShotAudioSource;
	public AudioSource gunHitAudioSource;
	public AudioSource gunFailAudioSource;
	public KeyCode shotKeycode;

	public GameObject fpsCameraKnockbackFrame;
	public Camera fpsCamera;

	private int raycastTargetLayer;

	public fps_hits_control fpsHitsControlScript;
	public fps_resource_script fpsResourceScript;

	private bool isKnockbackAnimationActive;
	private float knockbackAnimationStartTimestamp;

	public float knockbackAngle;
	public float knockbackAnimationDuration;

	public bool canShoot = true;

	// Use this for initialization
	void Start () {
		this.raycastTargetLayer = 1 << 8;
		this.isKnockbackAnimationActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(this.shotKeycode)) {
			if(this.canShoot && this.fpsResourceScript.getEstimatedFPS() > 0.0f) {
				this.onShotTrigger();
			} else if(this.canShoot) {
				this.gunFailAudioSource.Play();
			}
		}
		if (this.isKnockbackAnimationActive) {
			float t = (Time.time - this.knockbackAnimationStartTimestamp) / this.knockbackAnimationDuration;
			this.fpsCameraKnockbackFrame.transform.localEulerAngles = new Vector3((1-t) * (-this.knockbackAngle) + t * 0.0f,
																															0.0f,
																															0.0f);
			if (t > 1.0f) {
				this.fpsCameraKnockbackFrame.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
				this.isKnockbackAnimationActive = false;
			}
		}
		if (this.isHitMarkAnimationActive) {
			float t = (Time.time - this.hitMarkAnimationStartTimestamp) / this.hitMarkAnimationDuration;
			this.gunHitSpriteRender.color = new Vector4(1.0f, 1.0f, 1.0f, (1.0f - t) * 1.0f + t * 0.0f);

			if (t > 1.0f) {
				new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
				this.isHitMarkAnimationActive = false;
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
		this.fpsCameraKnockbackFrame.transform.localEulerAngles.Set(-this.knockbackAngle,
																														0.0f,
																														0.0f);
	}

	void onTargetHit(RaycastHit hit) {
		this.gunHitAudioSource.Play();
    this.fpsHitsControlScript.registerHit();
		this.isHitMarkAnimationActive = true;
		this.hitMarkAnimationStartTimestamp = Time.time;
	}

	void onTargetMiss() {
    this.fpsHitsControlScript.registerMiss();
	}
}
