using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWithBounds : MonoBehaviour {

	public Vector3 minCameraPosition;
	public Vector3 maxCameraPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < minCameraPosition.x) {
			//Debug.Log ("Falling off!");
			var temp = gameObject.GetComponent<Transform> ().position;
			temp.x = minCameraPosition.x;
			//Debug.Log ("Move " +gameObject.GetComponent<Transform> ().position + " To " + temp);
			gameObject.GetComponent<Transform>().position = temp;
		}

		if (transform.position.x > maxCameraPosition.x) {
			Debug.Log ("Falling off!");
			var temp = gameObject.GetComponent<Transform> ().position;
			temp.x = maxCameraPosition.x;
			gameObject.GetComponent<Transform>().position = temp;
		}
		
	}
}
