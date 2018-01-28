using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3_QuestionBubbles : MonoBehaviour {

	public GameObject SceneManager;
	public int choiceNum = 1;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {



	}

	void OnMouseDown(){
		
		if (SceneManager.GetComponent<Scene3_Controller> ().eventCounter == 1) {

			SceneManager.GetComponent<Scene3_Controller> ().choice1 = choiceNum;

			SceneManager.GetComponent<Scene3_Controller> ().eventCounter++;
		}

		if (SceneManager.GetComponent<Scene3_Controller> ().eventCounter == 3) {

			SceneManager.GetComponent<Scene3_Controller> ().choice2 = choiceNum;

			SceneManager.GetComponent<Scene3_Controller> ().eventCounter++;
		}

		if (SceneManager.GetComponent<Scene3_Controller> ().eventCounter == 5) {

			SceneManager.GetComponent<Scene3_Controller> ().choice3 = choiceNum;

			SceneManager.GetComponent<Scene3_Controller> ().eventCounter++;
		}
	}


}
