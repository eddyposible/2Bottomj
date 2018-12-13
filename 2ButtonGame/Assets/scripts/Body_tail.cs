using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_tail : MonoBehaviour {

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
		setTarget(targetTransform);
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
				Vector3 difference = targetTransform.position - this.transform.position;
				float rotationZ = Mathf.Atan2(difference.y,difference.x) * Mathf.Rad2Deg;
				myTransform.rotation = Quaternion.Euler(0f,0f,rotationZ);
                myTransform.position = Vector3.MoveTowards(transform.position,targetTransform.position,moveSpeed*Time.deltaTime);
            }
           
        }
		
	}
   public void setTarget(Transform targetTransform)
    {
        this.targetTransform = targetTransform;
    }
}
