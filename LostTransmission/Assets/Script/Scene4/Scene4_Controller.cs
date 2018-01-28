using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene4_Controller : MonoBehaviour {

	private string mainCharaName = "Niko Carter";
	private string name = "??????";
	public GameObject choiceButton1;
	public GameObject choiceButton2;
	public bool stayForDinner = false;



	public GameObject Carter;
	public GameObject WalkingControl;
	public GameObject CarterControl;
	public GameObject Camera;

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

	public Sprite ElderNormal;
	public Sprite ElderShock;
	public Sprite ElderTense;


	public Text frontDialogue;
	public Text frontName;



	//variables
	public Vector3 newCameraPos;
	public int eventCounter = 0;




	// Use this for initialization
	void Start () {

		fronttUIPanel.SetActive (false);
		choiceButton1.SetActive (false);
		choiceButton2.SetActive (false);

	}

	// Update is called once per frame
	void Update () {

		//make sure we are following the walk position if we are at the right event
		if (eventCounter == 0) {
			if (CarterControl.transform.position != WalkingControl.transform.position && isWalking != true) {
				isWalking = true;
				//Debug.Log ("PlayingWalkAnim");
				Carter.GetComponent<Animator> ().Play ("WalkAnim");

			} else if (CarterControl.transform.position == WalkingControl.transform.position && isWalking == true) {
				isWalking = false;
				Carter.GetComponent<Animator> ().Play ("Idle");
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


		if (eventCounter == 16) {

			if (stayForDinner != true) {
				
				fSpeak (mainCharaName, "worried", "You make a very generous offer... but I have to refuse. Thank you for your hospitality");
				eventCounter++;
			} else {
				fSpeak (mainCharaName, "norma;", "You make a very generous offer... I will gladly accept your hospitality");
				eventCounter++;
			}


		}


	}



	void OnMouseDown ()
	{
		if (eventCounter == 1) {

			fronttUIPanel.SetActive (true);
			fSpeak (mainCharaName, "normal", "Thank you for showing me the way. You have a lovely village.");
			eventCounter++;
			
		}
		else if (eventCounter == 2) {

			//fronttUIPanel.SetActive (true);
			fOtherSpeak (name, "normal", "Yeah... Well, you'll wnat to speak to the village elder. He'll know what to do with you.");
			eventCounter++;

		} else if (eventCounter == 3) {

			fSpeak (mainCharaName, "normal", "Thank You. I am in your debt");
			eventCounter++;


		} else if (eventCounter == 4) {

			fOtherSpeak (name, "confused", "... There's still something strange about you...");
			eventCounter++;

		} else if (eventCounter == 5) {
			
			fSpeak (mainCharaName, "confused", "Yes, well... I'll just go talk to the elder.");
			eventCounter++;
		} 
		else if (eventCounter == 6) {

			fSpeak (mainCharaName, "normal", "Good Evening, Sir. My name is " + mainCharaName + ". I am please to make your aquentance.");
			eventCounter++;
		} else if (eventCounter == 7) {

			fElderSpeak ("Elder", "confused", "You are different... Not of this planet.");
			eventCounter++;
		} else if (eventCounter == 8) {

			fSpeak (mainCharaName, "worried", "Unfortunately, I have crash landed on this planet. I mean you no harm but it would be difficult for me to repair my ship without proper materials.");
			eventCounter++;
		} else if (eventCounter == 9) {

			fElderSpeak ("Elder", "tense", "Of course... If you're not from this planet...");
			eventCounter++;
		}else if (eventCounter == 10) {

			fSpeak (mainCharaName, "confused", "Um, Sir?");
			eventCounter++;
		}else if (eventCounter == 11) {

			fElderSpeak ("Elder", "normal", "Yes, yes, well, what an interesting series of circumstances.");
			eventCounter++;
		}
		else if (eventCounter == 12) {

			fElderSpeak ("Elder", "normal", "But I do not wish to discuss it at this time. Stay here the night and we will speak of this again tomorrow morning.");
			eventCounter++;
		}
		else if (eventCounter == 13) {

			fSpeak (mainCharaName, "normal", "I couldn't possibly hope to impose on you like that. If you could juust spare some time to help m-");
			eventCounter++;
		}
		else if (eventCounter == 14) {

			fElderSpeak ("Elder", "tense", "Then stay for dinner, at the very least. Our culture dictates we must invite a person... such as yourself... to dinner before talking business.");
			eventCounter++;
		}
		else if (eventCounter == 15) {

			fSpeak (mainCharaName, "worried", "Hmmmm...");
			choiceButton1.SetActive (true);
			choiceButton2.SetActive (true);
			//eventCounter++;
	
		}
		else if (eventCounter >= 17) {

			Debug.Log ("Go To Next Scene");
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
		else
			frontCarter.sprite = CarterNormal;
	}

	void fOtherSpeak( string name, string emotion, string dialogue){
		frontName.text = "??????";
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

	void fElderSpeak( string name, string emotion, string dialogue){
		frontName.text = "Elder";
		frontDialogue.text = dialogue;
		if ( emotion == "normal")
			frontOther.sprite = ElderNormal;
		else if ( emotion == "shock" )
			frontOther.sprite = ElderShock;
		else if (emotion == "tense")
			frontOther.sprite = ElderTense ;
		else 
			frontOther.sprite = ElderNormal ;
	}

	public void stayForDin(){
		stayForDinner = true;
		eventCounter++;
		choiceButton1.SetActive (false);
		choiceButton2.SetActive (false);
	}

	public void leaveForDin(){
		stayForDinner = false;
		eventCounter++;
		choiceButton1.SetActive (false);
		choiceButton2.SetActive (false);
	}
}
