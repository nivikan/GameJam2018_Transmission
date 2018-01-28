using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {

	public GameObject objectToFollow;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = objectToFollow.transform.position;
		gameObject.transform.position = pos;
		
	}
}
