﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fps_shop_game : MonoBehaviour {

	public fps_gun_shot_script fpsGunShotScript;

	public Button buttonGotoShop;
	public Button buttonGotoGame;

	public Canvas gameCanvas;
	public Canvas shopCanvas;

	// Use this for initialization
	void Start () {
		this.onClickGotoGame();
	}
	
	// Update is called once per frame
	void Update () {
		this.buttonGotoShop.onClick.AddListener(onClickGotoShop);
		this.buttonGotoGame.onClick.AddListener(onClickGotoGame);
	}

	void onClickGotoShop()
	{
		this.gameCanvas.enabled = false;
		this.shopCanvas.enabled = true;
		this.fpsGunShotScript.canShoot = false;
	}

	void onClickGotoGame()
	{
		this.gameCanvas.enabled = true;
		this.shopCanvas.enabled = false;
		this.fpsGunShotScript.canShoot = true;
	}
}
