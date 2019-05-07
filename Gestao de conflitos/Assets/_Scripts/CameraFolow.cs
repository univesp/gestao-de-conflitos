using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour {

	public Transform target;

	float minX = -2.5f;

	float maxX = 16.8f;

	Vector3 cameraFixed;

	float targetX;
	void Start () {
		cameraFixed = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//cameraFixed = new Vector3()

		 targetX = target.position.x;


		//transform.position = Vector3.Slerp(transform.position, target.position, Time.deltaTime);
		if(targetX < minX )
			targetX = minX;
		if( targetX> maxX)
			targetX = maxX;



		transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetX, Time.deltaTime), cameraFixed.y,cameraFixed.z);
	}
}
