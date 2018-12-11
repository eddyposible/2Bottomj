using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    public float predictionCorrelation;
    public float correlationMax;
    public float correlationSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StartCorrelation(bool moveUp)
    {
        StopCoroutine(CorrelationCoroutine(moveUp));
        StartCoroutine(CorrelationCoroutine(moveUp));
    }
    //spawns an obstacle with random properties

    public IEnumerator CorrelationCoroutine(bool moveUp)
    {
        if (moveUp)
        {
            predictionCorrelation = 0;
            for (int i = 0; i < correlationMax; i++)
            {
                predictionCorrelation++;
                yield return new WaitForSeconds(correlationSpeed);
            }
        }
        if (!moveUp)
        {
            predictionCorrelation = 0;
            for (int i = 0; i < correlationMax; i++)
            {
                predictionCorrelation--;
                yield return new WaitForSeconds(correlationSpeed);
            }
        }
    }
}
