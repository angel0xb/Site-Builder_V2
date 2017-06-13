using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Selection : MonoBehaviour {

	public Camera mainCam; // it's not neccessary because we can get our camera from Camera.main

	public Text objectText; // it displays object name

	private CanvasGroup canvasGroup; // we use it to hide canvas 
	private GameObject lastSelected = null; // store last selected object reference

	void Awake () {
		canvasGroup = GetComponent<CanvasGroup> ();
		canvasGroup.alpha = 0f; // hide canvas
	}

	void Update () {
		if (Input.GetMouseButtonDown(0)) { // if LMB clicked
			bool cubeHit = false;
			RaycastHit raycastHit = new RaycastHit(); // create new raycast hit info object
			if (Physics.Raycast (mainCam.ScreenPointToRay (Input.mousePosition), out raycastHit)) { // create ray from screen's mouse position to world and store info in raycastHit object
				if (raycastHit.collider.tag == "Cube") { // we just want to hit objects tagged with "Cube"
					cubeHit = true; // yup, we hit it!
				} 
			}

			Deselect (lastSelected); // deselect last hit object
			if (cubeHit) 
				Select (raycastHit.collider.gameObject); // select new cube
		}
	}

	private void Select (GameObject g) {
		// when we select cube, we disable rotation script to make it stationary
		lastSelected = g;
//		g.GetComponent<RandomRotation> ().enabled = false;

		// display object's name in Text component, show canvas and move it above selected cube
		objectText.text = g.name;
		canvasGroup.alpha = 1f;
		Vector3 newPos = g.transform.position;
		newPos.z = -1f;
		transform.position = newPos;
	}

	private void Deselect (GameObject g) {
		if (lastSelected != null) { // if we have already selected object
//			g.GetComponent<RandomRotation> ().enabled = true; // enable its rotation
			canvasGroup.alpha = 0f; // make sure to hide canvas; we can hit nothing so we want to disable selection
		}
	}
}