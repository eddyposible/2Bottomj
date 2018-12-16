using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_point : MonoBehaviour {

	public float speed = 15f;
	public Rigidbody2D rgb;
	public Transform player;

	void Start () {
		rgb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += new Vector3(0f,player.position.y) + Vector3.right * speed;
		
	}
}
