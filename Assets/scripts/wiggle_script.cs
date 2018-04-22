using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wiggle_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f) * (Mathf.Abs(0.05f * Mathf.Sin(Time.time * 5.0f + 3.0f)) + 0.95f);
		this.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.5f * Mathf.Sin(Time.time * 5.0f + 3.0f));
	}
}
