using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseColorWhenOff : MonoBehaviour {

	public GameObject relatedObject;
	public Color bubbleCol;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (relatedObject.activeSelf) {
			gameObject.GetComponent<SpriteRenderer>().color = bubbleCol;

		} else {

			gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
			
		}
		
	}
}
