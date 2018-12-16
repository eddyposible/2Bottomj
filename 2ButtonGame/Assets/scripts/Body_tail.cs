using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_tail : MonoBehaviour {

    public float speed = 2.0f;
	public float accuracy = 5.0f;
    public Transform goal;

	// Use this for initialization
	void Start () {
        setTarget(goal);
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 difference = (goal.position -  new Vector3(.5f,0,0)) - this.transform.position;
		float rotationZ = Mathf.Atan2(difference.y,difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f,0f,rotationZ);
        if(difference.magnitude > accuracy)
        {
			transform.position += difference.normalized * Time.deltaTime * speed;
	    }  
        
		
	}
   public void setTarget(Transform targetTransform)
    {
        goal = targetTransform;
    }
}
