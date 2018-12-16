using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meter_ui_modifier : MonoBehaviour {

	public Body_tail_Joints body;
	public Animator animator;
	public int meter;

	void Start () {
		body = GameObject.FindGameObjectWithTag("Body").GetComponent<Body_tail_Joints>();
		animator = GetComponent<Animator> ();
	}
	
	void Update () {
		meter = body.meterBar;
		animator.SetInteger("Meter",meter);
	}
}
