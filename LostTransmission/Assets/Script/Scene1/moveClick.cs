using UnityEngine;
using System.Collections;

public class moveClick : MonoBehaviour {

	public Vector3 targetPosition;
	public GameObject SceneManager;

	// Update is called once per frame

	void Update () {


		// check to see if we are at the correct time in story
		if (SceneManager.GetComponent<Scene1_Controller>().eventCounter == 10) {

			//get mouse command and store position
			if (Input.GetKeyDown (KeyCode.Mouse0)) {

				targetPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		
			}


			//create new position with mouse's x position
			var newPosition = transform.position;
			newPosition.x = targetPosition.x;

			//move current object towards mouse click
			transform.position = Vector3.MoveTowards (transform.position, newPosition, Time.deltaTime * 2);



			// Change the direction the object is faciing
			if (transform.position.x > newPosition.x) {
				var temp = transform.localScale;
				if (temp.x > 0) {
					temp.x = -temp.x;
				}
				transform.localScale = temp;
			}
			//change the object back to front after going backwards
			else{
				if (transform.localScale.x < 0)
				{
					var temp = transform.localScale;
					temp.x = -temp.x;
					transform.localScale = temp;
				}
			}
		}
	}
}