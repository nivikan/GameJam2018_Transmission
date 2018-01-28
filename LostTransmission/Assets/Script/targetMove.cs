using UnityEngine;
using System.Collections;

public class targetMove : MonoBehaviour
{
	Vector3 newPosition;
	void Start () {
		newPosition = transform.position;
	}
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{

			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//Debug.Log (ray);
			if (Physics.Raycast(ray, out hit))
			{
				Debug.Log (ray);
				newPosition = hit.point;
				transform.position = newPosition;
			}
		}
	}
}