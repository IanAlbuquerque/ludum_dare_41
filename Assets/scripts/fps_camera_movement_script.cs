using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fps_camera_movement_script : MonoBehaviour {

	public float xCameraVariationAmplitude;
	public float yCameraVariationAmplitude;
	public float xCameraVariationDilatation;
	public float yCameraVariationDilatation;
	public float xCameraVariationOffset;
	public float yCameraVariationOffset;
	public Camera fpsCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	void LateUpdate () {
		this.fpsCamera.transform.eulerAngles = new Vector3(yCameraVariationAmplitude * Mathf.Sin(yCameraVariationDilatation * Time.time + yCameraVariationOffset),
																											 xCameraVariationAmplitude * Mathf.Sin(xCameraVariationDilatation * Time.time + xCameraVariationOffset),
																											 0.0f);
	}
}
