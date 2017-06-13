using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
	public GameObject selected;

	[SerializeField] private InputField p_height;
	[SerializeField] private InputField p_width;
	[SerializeField] private InputField p_length;
	public Camera mainCamera;
	public Canvas can;
	public float default_fov = 30.0f;
//	CanvasGroup canvasgroup = GameObject.Find("Canvas").GetComponent<CanvasGroup> ();

	Material newMat;

	/// Awake is called when the script instance is being loaded.
	void Awake()
	{
		can.gameObject.SetActive(false);
	}


	// Use this for initialization
	void Start()
	{
		p_height.placeholder.GetComponent<Text>().text = "Height";
		p_width.placeholder.GetComponent<Text>().text = "Width";
		p_length.placeholder.GetComponent<Text>().text = "Length";

	}

	// Update is called once per frame
	void Update()
	{

		///Click on an object to select it
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Mouse Clicked");
			if (!EventSystem.current.IsPointerOverGameObject ()) {
				RaycastHit hitInfo = new RaycastHit ();
				if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo)) {
				
					selected = hitInfo.transform.gameObject;
					print (selected.name);
					selected.GetComponent<Renderer> ().material = newMat;

					
					PopulateUI (selected);
//				canvasgroup.alpha = 1f;
					GameObject.Find ("Canvas").GetComponent<CanvasGroup> ().alpha = 1f;

				}
				// else{
				//     can.gameObject.SetActive(false);
				// }
			}

		}

		if (Input.GetMouseButtonUp (0)) {
			selected.GetComponent<Renderer> ().material = GameObject.Find ("Sphere").GetComponent<WallPoints>().brick;
		}
		///Mouse wheel zooms
		if (Input.GetAxis("Mouse ScrollWheel") < 0f)
		{
			print("Zooming in");
			mainCamera.fieldOfView--;
		}

		if (Input.GetAxis("Mouse ScrollWheel") > 0f)
		{
			print("Zooming out");
			mainCamera.fieldOfView++;
		}

		if (Input.GetMouseButtonDown(2))
		{
			mainCamera.fieldOfView = default_fov;
		}

	}

	/// <summary>
	/// LateUpdate is called every frame, if the Behaviour is enabled.
	/// It is called after all Update functions have been called.
	/// </summary>
	void LateUpdate()
	{

//		///Ugly Camera Rotation
//		if (Input.GetMouseButton(1))
//		{
//			Debug.Log("Right Click");
//			RotateCamera();
//		}

	}


	/// <summary>
	/// Flls in all the UI elements with their data values
	/// </summary>
	/// <param name="target"></param>
	public void PopulateUI(GameObject target)
	{
		print("Updating...");
		string height = target.transform.localScale.y.ToString();
		string width = target.transform.localScale.x.ToString();
		string length = target.transform.localScale.z.ToString();

		p_height.text = height;
		p_width.text = width;
		p_length.text = length;
		can.gameObject.SetActive(true);
	}

	/// <summary>
	/// Fills in the UI with the currently selected object'sdata values
	/// </summary>
	public void PopulateUI(){
		PopulateUI(selected);
		can.gameObject.SetActive(false);
	}

	/// <summary>
	/// Allows for mouse based rotation of the camera.
	/// </summary>
	void RotateCamera()
	{
		float x = Input.GetAxis("Mouse X");
		float y = Input.GetAxis("Mouse Y");
		Vector3 rotateValue = new Vector3(y, x * -1, 0);
		mainCamera.transform.eulerAngles = mainCamera.transform.eulerAngles - rotateValue;
	}

	public void SubmitData(){
		GameObject target = selected;
		float x = float.Parse(p_width.text);
		float y = float.Parse(p_height.text);
		float z = float.Parse(p_length.text);
		target.transform.localScale = new Vector3(x, y, z);
	}


	public void Cancel(){
//		canvasgroup.alpha = 0f;
		Debug.Log("canceling");
		GameObject.Find ("Canvas").GetComponent<CanvasGroup> ().alpha = 0f;
	}


	public void ToggleFloor(){
		GameObject floor = GameObject.Find("Floor");
		if (floor.GetComponent<Renderer> ().enabled == false) {
			ShowFloor ();
		} else {
			HideFloor ();
		}
		
	}

	public void HideFloor(){
		GameObject floor = GameObject.Find("Floor");
//		floor.SetActive (false);
		floor.GetComponent<Renderer>().enabled = false;
	}
	public void ShowFloor(){
		GameObject floor = GameObject.Find("Floor");
//		floor.SetActive (true);
		floor.GetComponent<Renderer>().enabled = true;
	}

}