using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene3_Controller : MonoBehaviour {

	private string mainCharaName = "Niko Carter";
	private string otherName = "??????";
	private string answer;

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
	public int choice2 = 0;
	public int choice3 = 0;


	// Use this for initialization
	void Start () {
		bubble1.SetActive (false);
		bubble2.SetActive (false);
		bubble3.SetActive (false);

		answerBubble.SetActive (false);

		fronttUIPanel.SetActive (false);

	}

	// Update is called once per frame
	void Update () {

		//make sure we are following the walk position if we are at the right event

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




		if (eventCounter == 2) {

			bubble1.SetActive (false);
			bubble2.SetActive (false);
			bubble3.SetActive (false);
			answerBubble.SetActive (true);

			answer = "";
			if (choice1 == 1)
				answer = "Answer to Question 1";
			else if (choice1 == 2)
				answer = "Answer to Question 2";
			else if (choice1 == 3)
				answer = "Answer to Question 3";

			answerBubble.GetComponent<Text> ().text = answer;
			eventCounter++;
		}
			


		if (eventCounter == 4) {

			bubble1.SetActive (false);
			bubble2.SetActive (false);
			bubble3.SetActive (false);
			answerBubble.SetActive (true);

			answer = "";
			if (choice2 == 1)
				answer = "2Answer to Question 1";
			else if (choice2 == 2)
				answer = "2Answer to Question 2";
			else if (choice2 == 3)
				answer = "2Answer to Question 3";

			answerBubble.GetComponent<Text> ().text = answer;
			eventCounter++;
		}

		if (eventCounter == 6) {

			bubble1.SetActive (false);
			bubble2.SetActive (false);
			bubble3.SetActive (false);
			answerBubble.SetActive (true);

			answer = "";
			if (choice3 == 1)
				answer = "3Answer to Question 1";
			else if (choice3 == 2)
				answer = "3Answer to Question 2";
			else if (choice3 == 3)
				answer = "3Answer to Question 3";

			answerBubble.GetComponent<Text> ().text = answer;
			eventCounter++;
		}



	}



	void OnMouseDown ()
	{
		if (Carter.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Idle") && eventCounter == 0) {
			eventCounter++;
			answerBubble.SetActive (false);
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
		}
		else if (eventCounter == 1) {

			answerBubble.SetActive (false);
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
			
		} else if (eventCounter == 3) {

			answerBubble.SetActive (false);
			bubble1.SetActive (true);
			bubble2.SetActive (true);
			bubble3.SetActive (true);

			Debug.Log ("Question 2");
			var question1 = "2Question 1";
			var question2 = "2Question 2 ";
			var question3 = "2Question 3";

			bubble1.GetComponent<Text> ().text = question1;
			bubble2.GetComponent<Text> ().text = question2;
			bubble3.GetComponent<Text> ().text = question3;

		} else if (eventCounter == 5) {

			answerBubble.SetActive (false);
			bubble1.SetActive (true);
			bubble2.SetActive (true);
			bubble3.SetActive (true);

			Debug.Log ("Question 3");
			var question1 = "3Question 1";
			var question2 = "3Question 2 ";
			var question3 = "3Question 3";

			bubble1.GetComponent<Text> ().text = question1;
			bubble2.GetComponent<Text> ().text = question2;
			bubble3.GetComponent<Text> ().text = question3;

		} 

		else if (eventCounter == 7) {

			answerBubble.SetActive (false);
			bubble1.SetActive (false);
			bubble2.SetActive (false);
			bubble3.SetActive (false);


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
