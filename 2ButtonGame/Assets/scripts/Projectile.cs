using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public Body_tail_Joints joints;
	public Transform player;
	public float speed = 10f;
	public Vector3 lastPosition;
	public Rigidbody2D rgb;
	public GameObject explotion;

	void Start () {
		joints = GameObject.FindGameObjectWithTag("Body").GetComponent<Body_tail_Joints> ();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform> ();
		rgb = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		Vector3 difference = player.position - transform.position;

		if (transform.position.x > player.position.x )
		{
			transform.position += difference.normalized * Time.deltaTime * speed;	
		}else{
			transform.position += Vector3.left;
		}
	}

	public void OnTriggerEnter2D (Collider2D other)
	{
		if(other.tag == "Player" || other.tag == "Tail" || other.tag == "Body")
		{
			joints.RemoveJoint();
			Instantiate(explotion,transform.position,Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
}
