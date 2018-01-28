using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene2_Controller : MonoBehaviour {

	private string mainCharaName = "Carter";
	private string otherName = "??????";

	public GameObject Carter;
	public GameObject WalkingControl;
	public GameObject CarterControl;
	public GameObject Camera;
	public GameObject Man;
	public GameObject OldMan;
	public bool menWalking = false;

	public bool isWalking = false;


	//for main talks/ front UI panel
	public GameObject fronttUIPanel;
	public Image frontCarter;
	public Image frontOther;
	public Sprite CarterNormal;
	public Sprite CarterConfused;
	public Sprite CarterWorried;

	public Sprite OtherNormal;
	public Sprite OtherSmile;
	public Sprite OtherAngry;
	public Sprite OtherConfused;


	public Text frontDialogue;
	public Text frontName;


	//Qestions
	public GameObject bubble1;
	public GameObject bubble2;
	public GameObject bubble3;
	public GameObject answerBubble;

	//variables
	public Vector3 newCameraPos;
	public int eventCounter = 0;



	//CHOICES
	public int choice1 = 0;


	// Use this for initialization
	void Start () {
		bubble1.SetActive (false);
		bubble2.SetActive (false);
		bubble3.SetActive (false);

		fronttUIPanel.SetActive (false);

	}

	// Update is called once per frame
	void Update () {

		//make sure we are following the walk position if we are at the right event
		if (eventCounter == 3 || eventCounter == 14 || eventCounter == 16) {
			if (CarterControl.transform.position != WalkingControl.transform.position && isWalking != true) {
				isWalking = true;
				//Debug.Log ("PlayingWalkAnim");
				Carter.GetComponent<Animator>().Play("WalkAnim");

			}
			else if( CarterControl.transform.position == WalkingControl.transform.position && isWalking == true)
			{
				isWalking = false;
				Carter.GetComponent<Animator>().Play("Idle");
			}
			CarterControl.transform.position = WalkingControl.transform.position;
			CarterControl.transform.localScale = WalkingControl.transform.localScale;

			// check if camera will leave canvas and, if ok, update the camera to follow player
			var tempPos = Camera.transform.position;
			var tempX = WalkingControl.transform.position.x;

			if (tempX > 0 && tempX < 18.5) {
				tempPos.x = tempX;
				Camera.transform.position = tempPos;
			}

		}
		//if (CarterControl.transform.position.x >= 3) {
		//}

		if (eventCounter == 15) {

			bubble1.SetActive (false);
			bubble2.SetActive (false);
			bubble3.SetActive (false);
			answerBubble.SetActive (true);

			var answer = "";
			if (choice1 == 1)
				answer = "Answer to Question 1";
			else if (choice1 == 2)
				answer = "Answer to Question 2";
			else if (choice1 == 3)
				answer = "Answer to Question 3";

			answerBubble.GetComponent<Text> ().text = answer;
			eventCounter++;
		}

	}



	void OnMouseDown ()
	{

		if (Carter.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Idle") && eventCounter == 0) {
			fronttUIPanel.SetActive (true);
			fSpeak (mainCharaName, "normal", "There are people over there");
			eventCounter++;
		} else if (eventCounter == 1) {

			fSpeak (mainCharaName, "worried", "Larger men, by the looks of it. They don't seem to be unfriendly... But they don't seem friendly either.");
			eventCounter++;
		} else if (eventCounter == 2) {

			fSpeak (mainCharaName, "worried", "... In any case, my uniform is reinforced. I can handle any issues. Right now, I better go get some information.");
			eventCounter++;
		} else if (eventCounter == 3) {
			fronttUIPanel.SetActive (false);
		} else if (eventCounter == 4) {
			fronttUIPanel.SetActive (true);
			fSpeak (mainCharaName, "normal", "Hello. I am a traveler from the squadrant five sector seven. My name is " + mainCharaName + " and I am an officer of the United Forces.");
			eventCounter++;
		} else if (eventCounter == 5) {
			fSpeak (mainCharaName, "normal", "I have crash landed here and my ship seems to be in repair. I would very much appreciate your help.");
			eventCounter++;
		} else if (eventCounter == 6 && Carter.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Idle")) {
			fOtherSpeak (otherName, "angry", "Your clothes... they look odd.");
			eventCounter++;
		} else if (eventCounter == 7) {

			fSpeak (mainCharaName, "worried", "I assure you. I will do you no harm. I simply need directions to the nearest transport epicenter.");
			eventCounter++;
		} else if (eventCounter == 8) {

			fOtherSpeak (otherName, "confused", "...");
			eventCounter++;
		} else if (eventCounter == 9) {
			fSpeak (mainCharaName, "confused", "Excuse me, it seems I've troubled you. Thank you for your time. I can handle myself from here.");
			eventCounter++;
		} else if (eventCounter == 10) {
			fOtherSpeak (otherName, "normal", "No... It's fine. I was just startled. We don't get strangers up here much. Especially not from off-Planet");
			eventCounter++;

		} else if (eventCounter == 11) {
			fOtherSpeak (otherName, "smile", "There's a village just up ahead. I'll show you the way.");
			eventCounter++;

		} else if (eventCounter == 12) {
			fSpeak (mainCharaName, "confused", "Thank you. I'll do just that.");
			eventCounter++;

		} else if (eventCounter == 13) {
			fronttUIPanel.SetActive (false);
			fSpeak (mainCharaName, "normal", "Thank you. I'll do just that.");
			eventCounter++;

		} else if (eventCounter == 14) {
			if (menWalking == false) {
				Man.GetComponent<Animator> ().Play ("ManAnim");
				OldMan.GetComponent<Animator> ().Play ("OldManWalk");

				var temp = Man.transform.localScale;
				temp.x = -temp.x;
				Man.transform.localScale = temp;

				temp = OldMan.transform.localScale;
				temp.x = -temp.x;
				OldMan.transform.localScale = temp;

				var temp2 = Man.transform.position;
				temp2.x = 16f;
				Man.transform.position = temp;

				temp2 = OldMan.transform.position;
				temp2.x = 18f;
				OldMan.transform.position = temp;


				menWalking = true;

			}
			Debug.Log ("played anim");
			bubble1.SetActive (true);
			bubble2.SetActive (true);
			bubble3.SetActive (true);

			Debug.Log ("Question 1");
			var question1 = "Question 1";
			var question2 = "Question 2 ";
			var question3 = "Question 3";


			bubble1.GetComponent<Text> ().text = question1;
			bubble2.GetComponent<Text> ().text = question2;
			bubble3.GetComponent<Text> ().text = question3;

		} else if (eventCounter == 16) {
			answerBubble.SetActive (false);

		}

		//eventCounter++;


		//click me
		// change event counter to 15
		// have variables for different questions.
		// change new string based on answer
			


	}





	void fSpeak( string name, string emotion, string dialogue){
		frontName.text = name;
		frontDialogue.text = dialogue;
		if ( emotion == "normal")
			frontCarter.sprite = CarterNormal;
		else if ( emotion == "worried" )
			frontCarter.sprite = CarterWorried;
		else if (emotion == "confused")
			frontCarter.sprite = CarterConfused ;
	}

	void fOtherSpeak( string name, string emotion, string dialogue){
		frontName.text = name;
		frontDialogue.text = dialogue;
		if ( emotion == "normal")
			frontOther.sprite = OtherNormal;
		else if ( emotion == "angry" )
			frontOther.sprite = OtherAngry;
		else if (emotion == "confused")
			frontOther.sprite = OtherConfused ;
		else 
			frontOther.sprite = OtherSmile ;
	}
}
