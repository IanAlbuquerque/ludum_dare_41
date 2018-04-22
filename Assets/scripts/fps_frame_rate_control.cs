using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fps_frame_rate_control : MonoBehaviour {

	public fps_resource_script fpsResourceScript;

	public Camera fpsCamera;

	// Use this for initialization
	IEnumerator Start () {
		this.fpsCamera.enabled = false;
		float timeElapsed = 0;
		this.fpsCamera.Render();
		while(true) {
			// Yields until end of frame
			yield return new WaitForEndOfFrame();
			timeElapsed += Time.deltaTime;
			float currentFps = Mathf.Min(Mathf.Max(this.fpsResourceScript.getEstimatedFPS(), 0.0f), 60.0f);
			if (currentFps > 0 && timeElapsed > 1 / currentFps) {
				timeElapsed = 0;
				this.fpsCamera.Render();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

}
