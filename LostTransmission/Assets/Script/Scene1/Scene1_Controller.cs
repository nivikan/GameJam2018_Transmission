using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene1_Controller : MonoBehaviour {

	private string mainCharaName = "Niko Carter";

	public GameObject Carter;
	public GameObject WalkingControl;
	public GameObject CarterControl;
	public GameObject Camera;

	public bool isWalking = false;

	//for main talks/ front UI panel
	public GameObject fronttUIPanel;
	public Image frontCarter;
	public Sprite CarterNormal;
	public Sprite CarterConfused;
	public Sprite CarterWorried;
	public Text frontDialogue;
	public Text frontName;


	//Qestions
	public GameObject bubble1;
	public GameObject bubble2;
	public GameObject bubble3;

	//variables
	public Vector3 newCameraPos;
	public int eventCounter = 0;




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
		if (eventCounter == 10) {
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
	}



	void OnMouseDown(){
		
		if (Carter.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle") && eventCounter == 0)
		{
			fronttUIPanel.SetActive (true);
			fSpeak(mainCharaName,"normal", "Where am I?");
			eventCounter++;
		}
		else if (eventCounter == 1)
		{
			
			fSpeak(mainCharaName,"worried", "That's right...");
			eventCounter++;
		}
		else if (eventCounter == 2)
		{
			
			fSpeak(mainCharaName,"confused", "The last thing I remember is the communication going down.");
			eventCounter++;
		}
		else if (eventCounter == 3)
		{
			
			fSpeak(mainCharaName,"worried", "It looks like I crash landed on this plannet.");
			eventCounter++;
		}
		else if (eventCounter == 4)
		{
			fronttUIPanel.SetActive (false);
			Carter.GetComponent<Animator>().Play("LookAround"); 
			eventCounter++;
		}
		else if (eventCounter == 5 && Carter.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle") )
		{
			fronttUIPanel.SetActive (true);
			fSpeak(mainCharaName,"confused", "I need help. I need food and water... I need to look around.");
			eventCounter++;
		}
		else if (eventCounter == 6 )
		{
			
			fSpeak(mainCharaName,"worried", "I think I'm in the sector of the quadrant with just as advanced technology.");
			eventCounter++;
		}
		else if (eventCounter == 7 )
		{
			
			fSpeak(mainCharaName,"normal", "Judging by the vegetation, there should be some life on this planet.");
			eventCounter++;
		}
		else if (eventCounter == 8 )
		{
			fSpeak(mainCharaName,"confused", "I hope they're friendly.");
			eventCounter++;
		}
		else if (eventCounter == 9 )
		{
			fronttUIPanel.SetActive (false);
			//CameraController.GetComponent<Animator>().Play("closeUp"); 
			//Vector3 newPos = (0,0,9);
			//CameraController.GetComponent<Transform>().position = Vector3.Lerp (transform.position, newCameraPos, 3f * Time.deltaTime);
			//CameraController.GetComponent<Transform>().position = newCameraPos;
			eventCounter++;

		}

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
}
