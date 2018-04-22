using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fps_resource_script : MonoBehaviour {

	public MeshRenderer fpsShooterScreen;
	public MeshRenderer failedScreen;

	public AudioSource mainButtonAudio;
	public Button fIncreaseButton;
	public Text fDisplayText;
	public Text fpsDisplayText;
	public Text shopfDisplayText;
	public Text shopfpsDisplayText;
	public TextMesh inGameFPSText;

	public float startingFroots;

	private float currentF;

	public float fpsSamplingInterval;

	private float samplingPassedTime;

	private float lastF;

	private float estimatedFPS;

	// Use this for initialization
	void Start () {
		this.fIncreaseButton.onClick.AddListener(onClickMainButton);
		this.setCurrentF(this.startingFroots);
		this.updateFText();
		this.samplingPassedTime = 0;
		this.lastF = 0;
		this.estimatedFPS = 0;
		this.updateFPSText();
	}
	
	// Update is called once per frame
	void Update () {
		this.samplingPassedTime += Time.deltaTime;
		if (this.samplingPassedTime > this.fpsSamplingInterval) {
			this.samplingPassedTime = 0;
			float newEstimatedFPS = (this.currentF - this.lastF) / this.fpsSamplingInterval;
			if (newEstimatedFPS >= 0) {
				this.estimatedFPS = newEstimatedFPS;
			}
			this.updateFPSText();
			this.lastF = this.currentF;
		}

		if (this.estimatedFPS > 0.0f) {
			this.failedScreen.enabled = false;
			this.fpsShooterScreen.enabled = true;
		} else {
			this.failedScreen.enabled = true;
			this.fpsShooterScreen.enabled = false;
		}
	}

	public void addToCurrentF(float value) {
		this.currentF += value;
		this.updateFText();
	}

	public void setCurrentF(float fpsRate) {
		this.currentF = fpsRate;
		this.updateFText();
	}

	public float getEstimatedFPS() {
		return this.estimatedFPS;
	}

	public float getCurrentF() {
		return this.currentF;
	}

	void updateFText() {
		this.fDisplayText.text = Mathf.Floor(this.currentF).ToString() + " FROOTS";
		this.shopfDisplayText.text = Mathf.Floor(this.currentF).ToString() + " FROOTS";
	}

	void updateFPSText() {
		this.fpsDisplayText.text = (Mathf.Ceil(this.estimatedFPS)).ToString() + " FPS";
		this.shopfpsDisplayText.text = (Mathf.Ceil(this.estimatedFPS)).ToString() + " FPS";
		this.inGameFPSText.text = (Mathf.Ceil(this.estimatedFPS)).ToString() + " FPS";
	}

	void onClickMainButton()
	{
		this.mainButtonAudio.pitch = Random.Range (0.9f,1.3f);
		this.mainButtonAudio.Play();
		this.currentF += 1;
		this.updateFText();
	}

}
