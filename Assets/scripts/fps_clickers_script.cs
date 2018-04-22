using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fps_clickers_script : MonoBehaviour {


	public float[] clickersCost;
	public float[] clickersFPS;
	
	public Text[] amountTexts;
	public Text[] costTexts;
	public Text[] fpsTexts;
	public Button[] buyButton;

	public float[] clickerCount;
	public int numClickers;

	private float timeElapsed;

	private Image[] buttonImages;

	public float increaseInterval;

	public float costMultiplier;

	public AudioSource adoptAudioSource;
	
	public fps_resource_script fpsResourceScript;

	public float getCount(int clickerIndex) {
		return this.clickerCount[clickerIndex];
	}

	public float getFPS(int clickerIndex) {
		return this.clickersFPS[clickerIndex];
	}

	// Use this for initialization
	void Start () {
		this.timeElapsed = 0.0f;
		this.buttonImages = new Image[this.numClickers];
		for(int i=0; i<this.numClickers; i++) {
			this.updateTexts(i);
			int clickerIndex = i; // important to instantiate another variable
			this.buyButton[i].onClick.AddListener(() => {this.onClickBuyClicker(clickerIndex);});
			this.buttonImages[i] = this.buyButton[i].GetComponent<Image>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		for(int i=0; i<this.numClickers; i++) {
			if (this.fpsResourceScript.getCurrentF() >= this.clickersCost[i]) {
				this.buyButton[i].interactable = true;
				this.buttonImages[i].color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
			} else {
				this.buyButton[i].interactable = false;
				this.buttonImages[i].color = new Vector4(0.7f, 0.7f, 0.7f, 0.2f);
			}
		}
		this.timeElapsed += Time.deltaTime;
		if (this.timeElapsed > this.increaseInterval) {
			for(int i=0; i<this.numClickers; i++) {
				this.fpsResourceScript.addToCurrentF(this.clickersFPS[i] * this.increaseInterval * this.clickerCount[i]);
			}
			this.timeElapsed = 0.0f;
		}

	}

	void updateTexts(int clickerIndex) {
		this.costTexts[clickerIndex].text = "Costs " + this.clickersCost[clickerIndex] + " Froots";
		this.fpsTexts[clickerIndex].text = "+" + this.clickersFPS[clickerIndex] + " FPS";
		this.amountTexts[clickerIndex].text = "x" + this.clickerCount[clickerIndex] + " Adopted";
	}

	void onClickBuyClicker(int clickerIndex) {
		if (this.fpsResourceScript.getCurrentF() >= this.clickersCost[clickerIndex]) {
			this.adoptAudioSource.Play();
			this.fpsResourceScript.addToCurrentF(-this.clickersCost[clickerIndex]);
			this.clickerCount[clickerIndex] += 1;
			this.clickersCost[clickerIndex] = Mathf.Floor(this.costMultiplier * this.clickersCost[clickerIndex]);
			this.updateTexts(clickerIndex);
		}
	}
}
