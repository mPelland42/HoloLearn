using UnityEngine;

public class SphereCommands : MonoBehaviour
{
	Vector3 originalPosition;

	// Use this for initialization
	void Start()
	{
		// Grab the original local position of the sphere when the app starts.
		originalPosition = this.transform.localPosition;
	}

	// Called by GazeGestureManager when the user performs a Select gesture
	void OnSelect()
	{
		// If the sphere has no Rigidbody component, add one to enable physics.
		gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, Camera.main.nearClipPlane + 4));
	}

	void OnPause(){
		var rigidbody = this.GetComponent<Rigidbody>();
		if (rigidbody != null)
		{
			rigidbody.isKinematic = true;
			Destroy(rigidbody);
		}
	}

	// Called by SpeechManager when the user says the "Reset world" command
	void OnReset()
	{
		// If the sphere has a Rigidbody component, remove it to disable physics.
		var rigidbody = this.GetComponent<Rigidbody>();
		if (rigidbody != null)
		{
			rigidbody.isKinematic = true;
			Destroy(rigidbody);
		}

		// Put the sphere back into its original local position.
		this.transform.localPosition = originalPosition;
	}

	void OnStop(){
		var rigidbody = this.GetComponent<Rigidbody>();
		if (rigidbody != null)
		{
			rigidbody.isKinematic = true;
			Destroy(rigidbody);
		}
	}

	// Called by SpeechManager when the user says the "Drop sphere" command
	void OnDrop()
	{
		// Just do the same logic as a Select gesture.
		OnSelect();
	}
}