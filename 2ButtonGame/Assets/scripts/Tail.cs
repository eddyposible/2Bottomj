using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour {
    public Transform myTransform; 
    public Transform targetTransform;
    //public Vector2 distance;
    public float Accuracy = 5.0f;
    public float followThreshold;
    public float moveSpeed;
    public float defaultSpeed;
    public float rotationSpeed;
    public float distance;
    public float catchupTreshold;
	// Use this for initialization
	void Start () {
        //myTransform = this.transform;

	}
    private void Awake()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void FixedUpdate () 
    {
        if(targetTransform != null)
        {
            

              
            /*myTransform.rotation = Quaternion.Slerp(
            myTransform.rotation,Quaternion.LookRotation(targetTransform.position - myTransform.position), rotationSpeed * Time.deltaTime);*/
            Vector3 difference = targetTransform.position - this.transform.position;
		    float rotationZ = Mathf.Atan2(difference.y,difference.x) * Mathf.Rad2Deg;
		    transform.rotation = Quaternion.Euler(0f,0f,rotationZ);
            if(difference.magnitude > Accuracy)
            {
                transform.position += difference.normalized * Time.deltaTime * defaultSpeed;
            }        
           
        }
		
	}
   public void setTarget(Transform targetTransform)
    {
        this.targetTransform = targetTransform;
    }
}
