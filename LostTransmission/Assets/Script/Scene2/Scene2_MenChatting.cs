using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2_MenChatting : MonoBehaviour {

	public GameObject chatBubble1;
	public GameObject chatBubble2;
	public GameObject LeftGuy;
	public GameObject RightGuy;

	public GameObject SceneManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){

		if (SceneManager.GetComponent<Scene2_Controller>().eventCounter == 3) {
			Debug.Log ("Clicked On Chatting Guys");

			LeftGuy.transform.localScale = RightGuy.transform.localScale;

			chatBubble1.SetActive (false);
			chatBubble2.SetActive (false);
			SceneManager.GetComponent<Scene2_Controller>().eventCounter = 4;
		}

	}
}
