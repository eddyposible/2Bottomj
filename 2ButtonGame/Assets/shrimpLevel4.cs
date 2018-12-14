using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrimpLevel4 : MonoBehaviour {

	public GameObject Projectile;
	public GameObject Target;

	void Start () {
		Target = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
		Vector3 distance = Target.transform.position - transform.position;
	}
}
