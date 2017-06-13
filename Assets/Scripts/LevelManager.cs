using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public int currentLevel;

	void Awake(){
		//Debug.Log("Hello.");
		currentLevel = SceneManager.GetActiveScene().buildIndex;
		//Debug.Log("This is Level "+currentLevel);
	}

	public void LoadLevel(string name)
    {
		
		//Debug.Log("Loading "+ currentLevel+1);
        SceneManager.LoadScene(name); 
		currentLevel = SceneManager.GetActiveScene().buildIndex;

    }

    public void Quit()
    {
        Debug.Log("Quit requested");
        Application.Quit();
        
    }

	public void LoadNextLevel(){
		Debug.Log(currentLevel);
		if(currentLevel>3) LoadLevel("Level_0"+(currentLevel+1));
		else LoadLevel("Win Screen");
	}

	void Update(){
		if(Input.GetKey(KeyCode.RightArrow)){
			print ("Moving...");
			LoadLevel("wallgen1");
			}
			}}

