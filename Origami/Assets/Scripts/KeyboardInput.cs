using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour {
	UnityEngine.TouchScreenKeyboard keyboard;
	public static string keyboardText = "";
	// Use this for initialization
	void Start () {
		
	}

	void OnNewEquation(){
		keyboard = TouchScreenKeyboard.Open ("", TouchScreenKeyboardType.Default, false, false, false, false, "Input your equation");
	}
	
	// Update is called once per frame
	void Update () {
		if (TouchScreenKeyboard.visible == false && keyboard != null) {
			if (keyboard.done == true) {
				keyboardText = keyboard.text;
				keyboard = null;
				gameObject.GetComponent<SurfaceDrawer>().updateEquation ("banana");
			}
		}
	}

}
