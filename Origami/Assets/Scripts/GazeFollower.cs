using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeFollower : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, Camera.main.nearClipPlane + 1));
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2-500, Screen.height/2+300, Camera.main.nearClipPlane+2));
		gameObject.transform.rotation = Camera.main.transform.rotation;
	}
}