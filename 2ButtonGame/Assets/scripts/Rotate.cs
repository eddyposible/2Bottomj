using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float rotateSpeed = 1;
    public bool right;
    public bool up;
    public bool forward;

   

	// Use this for initialization
	void Start () {

       

    }
	
	// Update is called once per frame
	void Update () {

        if (right) { transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed); }
        if (up) { transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed); }
        if (forward) { transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);}
        
		
	}
}
