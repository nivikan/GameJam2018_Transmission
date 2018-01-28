using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene5_Controller : MonoBehaviour {

	private string mainCharaName = "Niko Carter";
	private string name = "??????";


	//CHOICE 1
	public GameObject choiceButton1;
	public GameObject choiceButton2;
	public bool haveDrink = false;

	//CHOICE 2
	public GameObject choice2Button1;
	public GameObject choice2Button2;
	public bool shipCloseBy = false;


	//CHOICE 2
	public GameObject choice3Button1;
	public GameObject choice3Button2;
	public bool stayTheNight = false;




	public GameObject Carter;

	public GameObject CarterControl;
	public GameObject Camera;


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
		choice2Button1.SetActive (false);
		choice2Button2.SetActive (false);
		choice3Button1.SetActive (false);
		choice3Button2.SetActive (false);

	}

	// Update is called once per frame
	void Update () {


		if (eventCounter == 6) {

			if (haveDrink != true) {

				fSpeak ("smile", "I'm sorry, I would rather not drink. Even if it is an off hour, I am still on an official mission.");
				eventCounter++;
			} else {
				fSpeak ("smile", "Thank you. I would love some. Mmmmmm... The wine is really sweet. It tastes different from what I'm used to.");
				eventCounter++;
			}
			choiceButton1.SetActive (false);
			choiceButton2.SetActive (false);

		}

		if (eventCounter == 14) {

			if (shipCloseBy != true) {

				fSpeak ("worried", "Not very close, I'm afraid");
				eventCounter++;
			} else {
				fSpeak ("smile", "It's just past the opening to the left.");
				eventCounter++;
			}
			choice2Button1.SetActive (false);
			choice2Button2.SetActive (false);

		}

		if (eventCounter == 20) {

			if (stayTheNight != true) {

				fSpeak ("smile", "I'm sorry. I would really prefer just sleepung in my ship.");
				eventCounter++;
			} else {
				fSpeak ("smile", "Well, it couldn't hurt. I shall humbly accept your hospitality.");
				eventCounter++;
			}
			choice3Button1.SetActive (false);
			choice3Button2.SetActive (false);

		}


	}



	void OnMouseDown ()
	{

		if (eventCounter == 0) {
			eventCounter++;

		}
		else if (eventCounter == 1) {

			fronttUIPanel.SetActive (true);
			fSpeak ("normal", "Thank you for inviting me to stay here for dinner");
			eventCounter++;

		}
		else if (eventCounter == 2) {

			//fronttUIPanel.SetActive (true);
			fElderSpeak ("normal", "We are honored to entertain company such as yourself.");
			eventCounter++;

		} else if (eventCounter == 3) {

			fOtherSpeak ("normal", "Please, visitor, dig in. Make yourself right at home.");
			eventCounter++;


		} else if (eventCounter == 4) {

			fOtherSpeak ("smile", "Would you care for some wine? It's one of our best batches. We all grew it together");
			eventCounter++;

		} else if (eventCounter == 5) {

			fSpeak ("worried", "Well...");
			choiceButton1.SetActive (true);
			choiceButton2.SetActive (true);
		} 
		else if (eventCounter == 7) {

			fElderSpeak ( "normal", "So, Niko, was it? Tell me about your planet. What brings you here?");
			eventCounter++;
		} else if (eventCounter == 8) {

			fSpeak ("normal", "I've been on a deep space mission for a very long time... I've been escavating lost planets and research geodes forming in decaying world.");
			eventCounter++;
		} else if (eventCounter == 9) {

			fSpeak ("worried", "Unfortunately, my aircraft was suddenly knocked off course. It happened without warning. I tried to send a transmission back to my planet for help but I doubt anyone has recieved it.");
			eventCounter++;
		} else if (eventCounter == 10) {

			fElderSpeak ( "tense", "So I suppose you are all alone.");
			eventCounter++;
		}else if (eventCounter == 11) {

			fSpeak ("worried", "Um, Sir?");
			eventCounter++;
		}else if (eventCounter == 12) {

			fElderSpeak ("normal", "Yes, yes, well, is you're ship close to here, "+ mainCharaName + "? We'll need to see to it's repair in the morning.");
			eventCounter++;
		}
		else if (eventCounter == 13) {

			fSpeak ("worried", "Well...");
			choice2Button1.SetActive (true);
			choice2Button2.SetActive (true);
		}
		else if (eventCounter == 15) {

			fElderSpeak ("normal", "Good to know, good to know. So, I see you're done with dinner.");
			eventCounter++;
		}
		else if (eventCounter == 16) {

			fOtherSpeak ("smile", "You have to stay for the night. We can't let you stay out there all on your own.");
			eventCounter++;
		}
		else if (eventCounter == 17) {

			fSpeak ("worried", "Honestly, it's not that big of a deal. I can easily sleep in my ship.");
			eventCounter++;

		}
		else if (eventCounter == 18) {

			fOtherSpeak ("smile", "No, really, we insist that you stay here for the night.");
			eventCounter++;
		}
		else if (eventCounter == 19) {

			fSpeak ("worried", "I guess...");
			choice3Button1.SetActive (true);
			choice3Button2.SetActive (true);
		}
		else if (eventCounter == 21) {

			fSpeak ("worried", "I will retire for the night. Thank you so much for your hospitality.");
			eventCounter++;

		}
		else if (eventCounter >= 22) {

			Debug.Log ("TO NEXT SCENE");

		}



		//eventCounter++;


		//click me
		// change event counter to 15
		// have variables for different questions.
		// change new string based on answer



	}





	void fSpeak(string emotion, string dialogue){
		frontName.text = mainCharaName;
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

	void fOtherSpeak( string emotion, string dialogue){
		frontName.text = "Man";
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

	void fElderSpeak(string emotion, string dialogue){
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

	public void yesStayTheNight(){
		stayTheNight = true;
		eventCounter++;
		choice3Button1.SetActive (false);
		choice3Button2.SetActive (false);
	}

	public void dontStayNight(){
		stayTheNight = false;
		eventCounter++;
		choice3Button1.SetActive (false);
		choice3Button2.SetActive (false);
	}
	public void shipIsClose(){
		shipCloseBy= true;
		eventCounter++;
		choice2Button1.SetActive (false);
		choice2Button2.SetActive (false);
	}

	public void shipIsNotClose(){
		shipCloseBy = false;
		eventCounter++;
		choice2Button1.SetActive (false);
		choice2Button2.SetActive (false);
	}

	public void willHaveDrink(){
		haveDrink= true;
		eventCounter++;
		choice3Button1.SetActive (false);
		choice3Button2.SetActive (false);
	}

	public void dontHaveDrink(){
		haveDrink = false;
		eventCounter++;
		choice3Button1.SetActive (false);
		choice3Button2.SetActive (false);
	}
}
