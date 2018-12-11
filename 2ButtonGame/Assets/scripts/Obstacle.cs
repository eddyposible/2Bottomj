using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    public float sizeMin;
    public float sizeMax;



 
	// Use this for initialization
	void Start () 
    {
		
	}
 

    // Update is called once per frame
    void Update () {
     

       
	}
    public void SetSizeRandom()
    {
        float rnd1 = Random.Range(sizeMin, sizeMax);
        float rnd2 = Random.Range(sizeMin, sizeMax);
        float rnd3 = Random.Range(sizeMin, sizeMax);
        transform.localScale = new Vector3(rnd1, rnd2, rnd3);
    }

}
