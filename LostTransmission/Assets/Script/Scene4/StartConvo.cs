using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartConvo : MonoBehaviour {

	public GameObject SceneManager;
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if(SceneManager.GetComponent<Scene4_Controller> ().eventCounter == 0){
				
			SceneManager.GetComponent<Scene4_Controller> ().eventCounter++;
		}
	}
}
