using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour {
    public Transform myTransform; 
    public Transform targetTransform;
    //public Vector2 distance;
    public float followThreshold;
    public float moveSpeed;
    public float defaultSpeed;
    public float rotationSpeed;
    public float distance;
    public float catchupTreshold;
	// Use this for initialization
	void Start () {
        myTransform = this.transform;

	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if(targetTransform!=null)
        {
            distance = Vector3.Distance(myTransform.position, targetTransform.position);

            if (distance > followThreshold)
            {
                if (distance > followThreshold +catchupTreshold) 
                {
                    moveSpeed = moveSpeed + Mathf.Abs(distance);
                }
                else
                {
                    moveSpeed = defaultSpeed;
                }
                myTransform.rotation = Quaternion.Slerp(
                    myTransform.rotation,Quaternion.LookRotation(targetTransform.position - myTransform.position), rotationSpeed * Time.deltaTime);
                myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
            }
           
        }
		
	}
   public void setTarget(Transform targetTransform)
    {
        this.targetTransform = targetTransform;
    }
}
