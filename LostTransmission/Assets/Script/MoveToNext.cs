using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNext : MonoBehaviour {
	public string NextSceneName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		Debug.Log ("Move to scene " + NextSceneName);
		SceneManager.LoadScene(NextSceneName);

	}
}
