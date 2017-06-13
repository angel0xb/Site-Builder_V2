using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imagepract : MonoBehaviour {
	public Button click;
	public Button click2;

	public Canvas Picture1;
	public Canvas Picture2;


	// Use this for initialization
	void Start () {
		click = GetComponent<Button> ();
		Picture1 = GetComponent<Canvas> ();
		Picture1.enabled = false;

		click2 = GetComponent<Button> ();
		Picture2 = GetComponent<Canvas> ();
		Picture2.enabled = false;
	}

	// Update is called once per frame
	void Update () {

	}

	public void Button1()
	{
		Picture1.enabled = true;
	}

	public void Button2()
	{
		Picture2.enabled = true;
	}

}
