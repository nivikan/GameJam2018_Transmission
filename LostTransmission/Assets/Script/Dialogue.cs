using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour {

	public GameObject ConstantObject;
	public int GameBeatCount;

	public int dialoguePhase = 0;
	//0 = nothing is happening
	//1 = main char is about to ask question
	//2 = The new character is answering question

	public GameObject redPerson;
	public GameObject redPersonPanel1;
	public GameObject redPersonPanel2;
	public GameObject redPersonPanel3;

	public GameObject bluePerson;
	public GameObject bluePersonPanel1;
	public GameObject bluePersonPanel2;
	public GameObject bluePersonPanel3;

	public int choice1 = 0;
	public int choice2 = 0;
	public int choice3 = 0;

	// Use this for initialization
	void Start () {
		
		redPersonPanel1.SetActive (false);
		redPersonPanel2.SetActive (false);
		redPersonPanel3.SetActive (false);

		bluePersonPanel1.SetActive (false);
		bluePersonPanel2.SetActive (false);
		bluePersonPanel3.SetActive (false); 
	}
	
	// Update is called once per frame
	void Update () {
		if (dialoguePhase == 0) {
			redPersonPanel1.SetActive (false);
			redPersonPanel2.SetActive (false);
			redPersonPanel3.SetActive (false);

			bluePersonPanel1.SetActive (false);
			bluePersonPanel2.SetActive (false);
			bluePersonPanel3.SetActive (false); 
		}

		if (dialoguePhase == 1) {
			
			bluePersonPanel1.SetActive (false);
			bluePersonPanel2.SetActive (false);
			bluePersonPanel3.SetActive (false); 

		}
		if (dialoguePhase == 2) {
			redPersonPanel1.SetActive (false);
			redPersonPanel2.SetActive (false);
			redPersonPanel3.SetActive (false);

			string answer1 = "";
			string answer2 = "";
			string answer3 = "";

			if (GameBeatCount == 0) {
				answer1 = "Answer to question 1";
				answer2 = "Answer to question 2";
				answer3 = "Answer to question 3";
			}
			if (GameBeatCount == 1) {
				answer1 = "2Answer to question 1";
				answer2 = "2Answer to question 2";
				answer3 = "2Answer to question 3";
			}
			if (GameBeatCount == 2) {
				answer1 = "3Answer to question 1";
				answer2 = "3Answer to question 2";
				answer3 = "3Answer to question 3";
			}

			if (GameBeatCount == 0) {
				if (choice1 == 1) {
					bluePersonPanel2.SetActive (true);
					bluePersonPanel2.GetComponent<Text> ().text = answer1;

				} else if (choice1 == 2) {
					bluePersonPanel2.SetActive (true);
					bluePersonPanel2.GetComponent<Text> ().text = answer2;
				} else if (choice1 == 3) {
					bluePersonPanel2.SetActive (true);
					bluePersonPanel2.GetComponent<Text> ().text = answer3;
				}
			}
			if (GameBeatCount == 1) {
				if (choice2 == 1) {
					bluePersonPanel2.SetActive (true);
					bluePersonPanel2.GetComponent<Text> ().text = answer1;

				} else if (choice2 == 2) {
					bluePersonPanel2.SetActive (true);
					bluePersonPanel2.GetComponent<Text> ().text = answer2;
				} else if (choice2 == 3) {
					bluePersonPanel2.SetActive (true);
					bluePersonPanel2.GetComponent<Text> ().text = answer3;
				}
			}
			if (GameBeatCount == 2) {
				if (choice3 == 1) {
					bluePersonPanel2.SetActive (true);
					bluePersonPanel2.GetComponent<Text> ().text = answer1;

				} else if (choice3 == 2) {
					bluePersonPanel2.SetActive (true);
					bluePersonPanel2.GetComponent<Text> ().text = answer2;
				} else if (choice3 == 3) {
					bluePersonPanel2.SetActive (true);
					bluePersonPanel2.GetComponent<Text> ().text = answer3;
				}
			}

		}

	}

	void OnMouseDown()
	{
		Debug.Log ("CLICK!!");

		MakeConvo();
	}

	void MakeConvo()
	{
		if (dialoguePhase == 0) {

			if (GameBeatCount <= 2) {
				redPersonPanel1.SetActive (true);
				redPersonPanel2.SetActive (true);
				redPersonPanel3.SetActive (true);
			}

			string question1 = "";
			string question2 = "";
			string question3 = "";


			if (GameBeatCount == 0) {
				Debug.Log ("Question 1");
				question1 = "question 1";
				question2 = "question 2";
				question3 = "question 3";
			}

			if (GameBeatCount == 1) {
				Debug.Log ("Question 2");
				question1 = "2question 1";
				question2 = "2question 2";
				question3 = "2question 3";
			}

			if (GameBeatCount == 2) {
				Debug.Log ("Question 3");
				question1 = "question 1";
				question2 = "3question 2";
				question3 = "3question 3";

			}

			redPersonPanel1.GetComponent<Text> ().text = question1;
			redPersonPanel2.GetComponent<Text> ().text = question2;
			redPersonPanel3.GetComponent<Text> ().text = question3;
			dialoguePhase = 1;


		}


		if (dialoguePhase == 2) {
			dialoguePhase = 0;

			bluePersonPanel1.SetActive (false);
			bluePersonPanel2.SetActive (false);
			bluePersonPanel3.SetActive (false); 

			GameBeatCount++;
		}
	}

}
