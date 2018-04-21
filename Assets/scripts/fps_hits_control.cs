using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fps_hits_control : MonoBehaviour {

	public Text hitsText;
	public Text missesText;
	private int numHits;
	private int numMisses;

	// Use this for initialization
	void Start () {
		this.numHits = 0;
		this.numMisses = 0;
		this.updateHitsAndMissesText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void updateHitsAndMissesText() {
		this.hitsText.text = "HITS = " + this.numHits.ToString();
		this.missesText.text = "MISSES = " + this.numMisses.ToString();
	}

	public void registerHit() {
		this.numHits += 1;
		this.updateHitsAndMissesText();
	}

	public void registerMiss() {
		this.numMisses += 1;
		this.updateHitsAndMissesText();
	}
}
