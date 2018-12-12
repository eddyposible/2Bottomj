using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour {

	public GameObject Player;
	public Transform playerTransform;
	public float maxDistanceToPlayer;

	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		playerTransform = Player.GetComponent<Transform> ();
	}

	void Update () 
	{
		float distance = Vector3.Distance (transform.position,playerTransform.position);
		if (distance >= maxDistanceToPlayer){
			Destroy(this.gameObject);
		}
	}	
}	