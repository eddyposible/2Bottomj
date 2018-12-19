using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_player : MonoBehaviour {

	public GameObject player;
	public string whatToFollow = "x";

	void Update () {
		if(whatToFollow == "x")
		{
		transform.position = player.transform.position;
		} else
		{
			transform.position = new Vector2(transform.position.x, player.transform.position.y);
		}
	}
}
