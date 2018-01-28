using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2_QuestionBubbles : MonoBehaviour {

	public GameObject SceneManager;
	public int choiceNum = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}

	void OnMouseDown(){
		if (SceneManager.GetComponent<Scene2_Controller> ().eventCounter == 14) {
			
			SceneManager.GetComponent<Scene2_Controller> ().choice1 = choiceNum;

			SceneManager.GetComponent<Scene2_Controller> ().eventCounter++;
		}
	}
}
