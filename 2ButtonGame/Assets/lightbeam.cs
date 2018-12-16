using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightbeam : MonoBehaviour {

	public float speed;

	void Update () {
		transform.position += Vector3.right * speed* Time.deltaTime;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.tag == "Elite"){
			
			Elite_behaviour elite =	other.GetComponent<Elite_behaviour>();
			Destroy(this.gameObject);
		}
	}
}
