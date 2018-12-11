using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : ObjectSpawner {
    public List<GameObject> obstacles;
    public int obstacleSelector;
    public float frequency =10;
    public float obstacleSizeMax;
    public float obstacleSizeMin;
    public float verticalSpawnRange;
   
   


	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnCoroutine());
		
	}
	
	// Update is called once per frame
	void Update () {
     
      

	}




    IEnumerator SpawnCoroutine()
    {

        obstacleSelector = Random.Range(0, obstacles.Count);
        Vector3 randomVector = new Vector3(transform.position.x, transform.position.y + Random.Range(-verticalSpawnRange, verticalSpawnRange)+predictionCorrelation, transform.position.z);

        GameObject tempGameObject = GameObject.Instantiate(obstacles[obstacleSelector], randomVector, transform.rotation);
 
        yield return new WaitForSeconds(frequency);
        StartCoroutine(SpawnCoroutine());
    }


}
