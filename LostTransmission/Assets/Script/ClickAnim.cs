using UnityEngine;
using System.Collections;

public class ClickAnim : MonoBehaviour {

	public Vector3 targetPosition;

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			var temp = transform.position;
			temp.x = targetPosition.x;
			temp.y = targetPosition.y;
			transform.position = temp;
			gameObject.GetComponent<Animator>().Play("ClickAnim");
			Debug.Log ("cursor");
		}
			
	}
}