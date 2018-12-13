using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrimp_velocity : Enemy {

	public float directionY;
	public float directionX;
	
	void Update () {
		Vector3 newPos = transform.position + new Vector3(directionX * moveSpeed * Time.deltaTime, directionY * moveSpeed * Time.deltaTime, 0f);
		transform.position = newPos;
	}
}
