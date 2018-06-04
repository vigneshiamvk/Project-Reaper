using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class SpinScript : MonoBehaviour {

	public float spinValue = 90;
	public TextMesh promtText;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update ()
	{
		transform.Rotate(Vector3.up * spinValue * Time.deltaTime);
	}

	public void flipSpin()
	{
		spinValue = -spinValue;
	}

	public void displayPrompt()
	{
		StartCoroutine (displayMsg (promtText, "This is a Cube. Click to Invert Rotation.", 5f));
	}

	public IEnumerator displayMsg (TextMesh uiText, String displayText, float timeLimit)
	{
		uiText.text = displayText;

		yield return new WaitForSeconds (timeLimit);

		uiText.text = "";
	}
}
