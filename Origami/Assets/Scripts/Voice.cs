using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class Voice : MonoBehaviour {

	private DictationRecognizer dictationRecognizer;

	// Use this for initialization
	void Start () {
		SurfaceDrawer.function = new BinaryExpression ("x^3");
	dictationRecognizer = new DictationRecognizer ();
		dictationRecognizer.DictationHypothesis += (text) => {change(text);};
		dictationRecognizer.DictationError += (error, hresult) => {SurfaceDrawer.function = new BinaryExpression ("x^2");};
	dictationRecognizer.Start ();


	}

	// Update is called once per frame
	void Update () {


	}
	private void change (string text) {
		text = text.Replace ("over", "/");
		text = text.Replace ("plus", "+");
		text = text.Replace ("minus", "-");
		text = text.Replace ("to the", "^");
		SurfaceDrawer.function = new BinaryExpression (text);

	}

}
