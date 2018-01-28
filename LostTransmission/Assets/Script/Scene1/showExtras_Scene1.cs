using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showExtras_Scene1 : MonoBehaviour {

	public GameObject SceneManager;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	void OnMouseDown(){
		
		Debug.Log ("Hit");
		if (SceneManager.GetComponent<Scene1_Controller>().eventCounter == 10)
		{
			gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		}
	}
}
