using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickChoice : MonoBehaviour {

	public int  choiceNumber = 0; //this is the choice number in the set of 3 choices

	public GameObject gameManager;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if (gameManager.GetComponent<Dialogue> ().choice1 == 0 && gameManager.GetComponent<Dialogue> ().GameBeatCount == 0) {
			gameManager.GetComponent<Dialogue> ().choice1 = choiceNumber;
			gameManager.GetComponent<Dialogue> ().dialoguePhase = 2;
			return;
		}
		if (gameManager.GetComponent<Dialogue> ().choice2 == 0 && gameManager.GetComponent<Dialogue> ().GameBeatCount == 1) {
			gameManager.GetComponent<Dialogue> ().choice2 = choiceNumber;
			gameManager.GetComponent<Dialogue> ().dialoguePhase = 2;
			return;
		}
		if (gameManager.GetComponent<Dialogue> ().choice3 == 0 && gameManager.GetComponent<Dialogue> ().GameBeatCount == 2) {
			gameManager.GetComponent<Dialogue> ().choice3 = choiceNumber;
			gameManager.GetComponent<Dialogue> ().dialoguePhase = 2;
			return;
		}
		gameObject.SetActive (false);
	}
}
