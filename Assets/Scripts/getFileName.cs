using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getFileName : MonoBehaviour {
	public string filePath;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(GameObject.Find ("FileName"));
//		Component fileP = GameObject.Find ("FileName").GetComponent(filePath);	
	}

	// Update is called once per frame
	void Update () {
//		Debug.Log (filePath);
//		GameObject.Find ("FileName").DontDestroyOnLoad;
//		string fileP = GameObject.Find ("FileName").GetComponent(filePath);
		
	}
}
