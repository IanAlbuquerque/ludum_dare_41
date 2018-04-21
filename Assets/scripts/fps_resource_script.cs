using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fps_resource_script : MonoBehaviour {

	public Button fpsIncreaseButton;
	public Text fpsDisplayText;

	public float fpsIncreaseStep;
	public float startingFPS;

	private float currentFPS;

	// Use this for initialization
	void Start () {
		this.fpsIncreaseButton.onClick.AddListener(onClickFPSIncreaseButton);
		this.setCurrentFPS(this.startingFPS);
		this.updateFPSText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setCurrentFPS(float fpsRate) {
		this.currentFPS = fpsRate;
	}

	public float getCurrentFPS() {
		return this.currentFPS;
	}

	void updateFPSText() {
		this.fpsDisplayText.text = "FPS = " + this.currentFPS.ToString();
	}

	void onClickFPSIncreaseButton()
	{
		this.currentFPS += this.fpsIncreaseStep;
		this.updateFPSText();
	}

}
