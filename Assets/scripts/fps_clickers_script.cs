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

	public float increaseInterval;
	
	public fps_resource_script fpsResourceScript;

	// Use this for initialization
	void Start () {
		this.timeElapsed = 0.0f;
		for(int i=0; i<this.numClickers; i++) {
			this.costTexts[i].text = "Costs " + this.clickersCost[i] + " Froots";
			this.fpsTexts[i].text = "+" + this.clickersFPS[i] + " FPS";
			this.amountTexts[i].text = "x" + this.clickerCount[i] + " Adopted";
		}
	}
	
	// Update is called once per frame
	void Update () {
		this.timeElapsed += Time.deltaTime;
		if (this.timeElapsed > this.increaseInterval) {
			for(int i=0; i<this.numClickers; i++) {
				this.fpsResourceScript.addToCurrentF(this.clickersFPS[i] * this.increaseInterval * this.clickerCount[i]);
			}
			this.timeElapsed = 0.0f;
		}

	}
}
